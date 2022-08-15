using System;
using System.Collections.Generic;
using System.Linq;
using Spectre.Console;
using TimelessEmulator.Data;
using TimelessEmulator.Data.Models;
using TimelessEmulator.Game;


namespace TimelessEmulator;

public static class Program
{

    static Program()
    {

    }

    public static void Main(string[] arguments)



    {
        //var duelist_ids = new List<int> { 1325, 3009, 3319, 4565, 4833, 7786, 8544, 10073, 11364, 11859, 12236, 14813, 16544, 17201, 17383, 17566, 18103, 19730, 19750, 19782, 21435, 22423, 23066, 24083, 24641, 25324, 25456, 26456, 28863, 29185, 29933, 30155, 30842, 31471, 32053, 32059, 34031, 34666, 34973, 35977, 36200, 36222, 36972, 37584, 38772, 39338, 43303, 43412, 43413, 43684, 45358, 46730, 47030, 48438, 48859, 49109, 49147, 49416, 49538, 49971, 52632, 54127, 55648, 56001, 57949, 58541, 58545, 58803, 59766, 60002, 62588, 63027, 65400 };

        var duelist_ids = new List<string> { "golem's_blood1088", "dual_wield_damage1859", "shield_block35", "dual_wield_speed567", "maximum_endurance_charges133", "totem_attack_damage2676", "dexterity840", "armour_guards_2378", "poison_bleed_chance_2179", "strength1984", "melee_physical_damage_with_shield1854", "mana_on_kill_notable1704", "dexterity838", "dexterity987", "mana_on_kill1475", "armour_and_evasion1454", "dexterity1990_", "stances_notable2758_", "mastery_evasion115", "defences_with_shield1857", "leather_and_steel1458", "dual_wield_damage622", "maximum_frenzy_charges527", "strength1005", "dual_wield_damage621", "melee_physical_damage_with_shield1856", "dervish1028", "mace_damage_and_armour1568", "mastery_attack13", "two_hand_crit2539", "life1196", "projectile_damage1860", "two_hand_damage1862", "life1213", "stances2757", "two_hand_crit_notable2542", "strength1004", "executioner648", "warcry_empowered_notable2713", "mastery_warcry251", "warcry_empowered2712", "projectile_damage1131", "two_handed_attack_speed649", "endurance_charge_duration2003", "stances2756", "mastery_twohand245_", "two_hand_damage1861", "two_handed_damage646", "shield_block33", "poison_bleed_duration_2180", "mastery_armour11", "melee_physical_damage_with_shield1855", "projectile_damage1271", "life_armour_evasion_notable1853", "mastery_mana171", "armour_and_evasion1453", "armour_guards_2379", "armour_guards_notable_2380", "melee_physical_damage_with_shield_notable1858", "frenzy_charge_duration2006", "projectile_damage1130", "jewel_slot1975", "totem_attack_damage2677", "strength1983", "mastery_damageovertime82", "mace_damage77", "mana_on_kill1476", "two_hand_crit2541", "poison_bleed_notable_2181", "fury_bolts1132", "mastery_life138", "warcry_empowered2710", "warcry_empowered2711" };
        var testJewel = new TestJewel();

        testJewel.ProcessIds(duelist_ids);

        Console.Title = $"{Settings.ApplicationName} Ver. {Settings.ApplicationVersion}";

        AnsiConsole.MarkupLine("Hello, [green]exile[/]!");
        AnsiConsole.MarkupLine("Loading [green]data files[/]...");

        if (!DataManager.Initialize())
            ExitWithError("Failed to initialize the [yellow]data manager[/].");

        PassiveSkill passiveSkill = GetPassiveSkillFromInput();

        if (passiveSkill == null)
            ExitWithError("Failed to get the [yellow]passive skill[/] from input.");

        TimelessJewel timelessJewel = GetTimelessJewelFromInput();

        if (timelessJewel == null)
            ExitWithError("Failed to get the [yellow]timeless jewel[/] from input.");

        AnsiConsole.WriteLine();

        AlternateTreeManager alternateTreeManager = new AlternateTreeManager(passiveSkill, timelessJewel);

        bool isPassiveSkillReplaced = alternateTreeManager.IsPassiveSkillReplaced();

        AnsiConsole.MarkupLine($"[green]Is Passive Skill Replaced[/]: {isPassiveSkillReplaced}");

        if (isPassiveSkillReplaced)
        {
            AlternatePassiveSkillInformation alternatePassiveSkillInformation = alternateTreeManager.ReplacePassiveSkill();

            AnsiConsole.MarkupLine($"[green]Alternate Passive Skill[/]: [yellow]{alternatePassiveSkillInformation.AlternatePassiveSkill.Name}[/] ([yellow]{alternatePassiveSkillInformation.AlternatePassiveSkill.Identifier}[/])");

            for (int i = 0; i < alternatePassiveSkillInformation.AlternatePassiveSkill.StatIndices.Count; i++)
            {
                uint statIndex = alternatePassiveSkillInformation.AlternatePassiveSkill.StatIndices.ElementAt(i);
                uint statRoll = alternatePassiveSkillInformation.StatRolls.ElementAt(i).Value;

                AnsiConsole.MarkupLine($"\t\tStat [yellow]{i}[/] | [yellow]{DataManager.GetStatTextByIndex(statIndex)}[/] (Identifier: [yellow]{DataManager.GetStatIdentifierByIndex(statIndex)}[/], Index: [yellow]{statIndex}[/]), Roll: [yellow]{statRoll}[/]");
            }

            PrintAlternatePassiveAdditionInformations(alternatePassiveSkillInformation.AlternatePassiveAdditionInformations);
        }
        else
        {
            IReadOnlyCollection<AlternatePassiveAdditionInformation> alternatePassiveAdditionInformations = alternateTreeManager.AugmentPassiveSkill();

            PrintAlternatePassiveAdditionInformations(alternatePassiveAdditionInformations);
        }

        WaitForExit();
    }

    private static PassiveSkill GetPassiveSkillFromInput()
    {
        TextPrompt<string> passiveSkillTextPrompt = new TextPrompt<string>("[green]Passive Skill[/]:")
            .Validate((string input) =>
            {
                PassiveSkill passiveSkill = DataManager.GetPassiveSkillByFuzzyValue(input);

                if (passiveSkill == null)
                    return ValidationResult.Error($"[red]Error[/]: Unable to find [yellow]passive skill[/] `{input}`.");

                if (!DataManager.IsPassiveSkillValidForAlteration(passiveSkill))
                    return ValidationResult.Error($"[red]Error[/]: The [yellow]passive skill[/] `{input}` is not valid for alteration.");

                return ValidationResult.Success();
            });

        string passiveSkillInput = AnsiConsole.Prompt(passiveSkillTextPrompt);

        PassiveSkill passiveSkill = DataManager.GetPassiveSkillByFuzzyValue(passiveSkillInput);

        AnsiConsole.MarkupLine($"[green]Found Passive Skill[/]: [yellow]{passiveSkill.Name}[/] ([yellow]{passiveSkill.Identifier}[/])");

        return passiveSkill;
    }

    private static TimelessJewel GetTimelessJewelFromInput()
    {
        Dictionary<uint, string> timelessJewelTypes = new Dictionary<uint, string>()
        {
            { 1, "Glorious Vanity" },
            { 2, "Lethal Pride" },
            { 3, "Brutal Restraint" },
            { 4, "Militant Faith" },
            { 5, "Elegant Hubris" }
        };

        Dictionary<uint, Dictionary<string, TimelessJewelConqueror>> timelessJewelConquerors = new Dictionary<uint, Dictionary<string, TimelessJewelConqueror>>()
        {
            {
                1, new Dictionary<string, TimelessJewelConqueror>()
                {
                    { "Xibaqua", new TimelessJewelConqueror(1, 0) },
                    { "[springgreen3]Zerphi (Legacy)[/]", new TimelessJewelConqueror(2, 0) },
                    { "Ahuana", new TimelessJewelConqueror(2, 1) },
                    { "Doryani", new TimelessJewelConqueror(3, 0) }
                }
            },
            {
                2, new Dictionary<string, TimelessJewelConqueror>()
                {
                    { "Kaom", new TimelessJewelConqueror(1, 0) },
                    { "Rakiata", new TimelessJewelConqueror(2, 0) },
                    { "[springgreen3]Kiloava (Legacy)[/]", new TimelessJewelConqueror(3, 0) },
                    { "Akoya", new TimelessJewelConqueror(3, 1) }
                }
            },
            {
                3, new Dictionary<string, TimelessJewelConqueror>()
                {
                    { "[springgreen3]Deshret (Legacy)[/]", new TimelessJewelConqueror(1, 0) },
                    { "Balbala", new TimelessJewelConqueror(1, 1) },
                    { "Asenath", new TimelessJewelConqueror(2, 0) },
                    { "Nasima", new TimelessJewelConqueror(3, 0) }
                }
            },
            {
                4, new Dictionary<string, TimelessJewelConqueror>()
                {
                    { "[springgreen3]Venarius (Legacy)[/]", new TimelessJewelConqueror(1, 0) },
                    { "Maxarius", new TimelessJewelConqueror(1, 1) },
                    { "Dominus", new TimelessJewelConqueror(2, 0) },
                    { "Avarius", new TimelessJewelConqueror(3, 0) }
                }
            },
            {
                5, new Dictionary<string, TimelessJewelConqueror>()
                {
                    { "Cadiro", new TimelessJewelConqueror(1, 0) },
                    { "Victario", new TimelessJewelConqueror(2, 0) },
                    { "[springgreen3]Chitus (Legacy)[/]", new TimelessJewelConqueror(3, 0) },
                    { "Caspiro", new TimelessJewelConqueror(3, 1) }
                }
            }
        };

        Dictionary<uint, (uint minimumSeed, uint maximumSeed)> timelessJewelSeedRanges = new Dictionary<uint, (uint minimumSeed, uint maximumSeed)>()
        {
            { 1, (100, 8000) },
            { 2, (10000, 18000) },
            { 3, (500, 8000) },
            { 4, (2000, 10000) },
            { 5, (2000, 160000) }
        };

        SelectionPrompt<string> timelessJewelTypeSelectionPrompt = new SelectionPrompt<string>()
            .Title("[green]Timeless Jewel Type[/]:")
            .AddChoices(timelessJewelTypes.Values.ToArray());

        string timelessJewelTypeInput = AnsiConsole.Prompt(timelessJewelTypeSelectionPrompt);

        AnsiConsole.MarkupLine($"[green]Timeless Jewel Type[/]: {timelessJewelTypeInput}");

        uint alternateTreeVersionIndex = timelessJewelTypes
            .First(q => (q.Value == timelessJewelTypeInput))
            .Key;

        AlternateTreeVersion alternateTreeVersion = DataManager.AlternateTreeVersions
            .First(q => (q.Index == alternateTreeVersionIndex));

        SelectionPrompt<string> timelessJewelConquerorSelectionPrompt = new SelectionPrompt<string>()
            .Title("[green] Timeless Jewel Conqueror[/]:")
            .AddChoices(timelessJewelConquerors[alternateTreeVersionIndex].Keys.ToArray());

        string timelessJewelConquerorInput = AnsiConsole.Prompt(timelessJewelConquerorSelectionPrompt);

        AnsiConsole.MarkupLine($"[green]Timeless Jewel Conqueror[/]: {timelessJewelConquerorInput}");

        TimelessJewelConqueror timelessJewelConqueror = timelessJewelConquerors[alternateTreeVersionIndex]
            .First(q => (q.Key == timelessJewelConquerorInput))
            .Value;

        TextPrompt<uint> timelessJewelSeedTextPrompt = new TextPrompt<uint>($"[green]Timeless Jewel Seed ({timelessJewelSeedRanges[alternateTreeVersionIndex].minimumSeed} - {timelessJewelSeedRanges[alternateTreeVersionIndex].maximumSeed})[/]:")
            .Validate((uint input) =>
            {
                if ((input >= timelessJewelSeedRanges[alternateTreeVersionIndex].minimumSeed) &&
                    (input <= timelessJewelSeedRanges[alternateTreeVersionIndex].maximumSeed))
                {
                    return ValidationResult.Success();
                }

                return ValidationResult.Error($"[red]Error[/]: The [yellow]timeless jewel seed[/] must be between {timelessJewelSeedRanges[alternateTreeVersionIndex].minimumSeed} and {timelessJewelSeedRanges[alternateTreeVersionIndex].maximumSeed}.");
            });

        uint timelessJewelSeed = AnsiConsole.Prompt(timelessJewelSeedTextPrompt);

        return new TimelessJewel(alternateTreeVersion, timelessJewelConqueror, timelessJewelSeed);
    }

    private static void PrintAlternatePassiveAdditionInformations(IReadOnlyCollection<AlternatePassiveAdditionInformation> alternatePassiveAdditionInformations)
    {
        ArgumentNullException.ThrowIfNull(alternatePassiveAdditionInformations, nameof(alternatePassiveAdditionInformations));

        foreach (AlternatePassiveAdditionInformation alternatePassiveAdditionInformation in alternatePassiveAdditionInformations)
        {
            AnsiConsole.MarkupLine($"\t[green]Addition[/]: [yellow]{alternatePassiveAdditionInformation.AlternatePassiveAddition.Identifier}[/]");

            for (int i = 0; i < alternatePassiveAdditionInformation.AlternatePassiveAddition.StatIndices.Count; i++)
            {
                uint statIndex = alternatePassiveAdditionInformation.AlternatePassiveAddition.StatIndices.ElementAt(i);
                uint statRoll = alternatePassiveAdditionInformation.StatRolls.ElementAt(i).Value;

                AnsiConsole.MarkupLine($"\t\tStat [yellow]{i}[/] | [yellow]{DataManager.GetStatTextByIndex(statIndex)}[/] (Identifier: [yellow]{DataManager.GetStatIdentifierByIndex(statIndex)}[/], Index: [yellow]{statIndex}[/]), Roll: [yellow]{statRoll}[/]");
            }
        }
    }

    private static void WaitForExit()
    {
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine("Press [yellow]any key[/] to exit.");

        try
        {
            Console.ReadKey();
        }
        catch { }

        Environment.Exit(0);
    }

    private static void PrintError(string error)
    {
        AnsiConsole.MarkupLine($"[red]Error[/]: {error}");
    }

    private static void ExitWithError(string error)
    {
        PrintError(error);
        WaitForExit();
    }

}
