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
        var left_scion_socket_ids = new List<string> { "attack_speed1285", "skill_duration_notable1787", "mana_regeneration1276", "mastery_elemental98", "area_of_effect_radius1061", "mana391", "jewel_slot1966", "skill_duration436", "cast_speed1547", "intelligence879", "mana_notable1765", "spell_damage1293", "mastery_physical193_", "mastery_life128", "path_of_the_warrior1537", "skill_duration1788", "melee_damage1284", "energy_shield298", "energy_shield295", "life193", "attack_speed1279", "strength797", "melee_damage1283", "mastery_energyshield100", "physical_damage2831", "life1406", "block1301", "energy_shield297", "cast_speed1546", "mastery_curse71", "mana395", "life_regeneration1084", "physical_damage_hits_notable2829", "curse_alternate2806", "curse_alternate2805", "intelligence884", "fire_resistance1288", "physical_damage2830", "curse_alternate_notable2807", "cold_resistance1289", "path_of_the_savant1538", "mana389", "life_regeneration1085", "area_of_effect_radius1060", "projectile_damage1295", "mastery_duration92", "energy_shield296", "necromantic_aegis1175", "elemental_damage_notable1727", "mana393", "physical_damage_dots_notable2832", "block1302", "curse_alternate2804", "strength997", "spell_damage1277", "elemental_damage1725", "mana390", "melee_damage1281", "iron_will_keystone2850", "area_of_effect_radius1062", "life1280", "elemental_damage1726", "life_regeneration1087", "spell_damage1292", "physical_damage2828", "life180", "projectile_damage1278", "melee_damage1282", "cast_speed1548", "shaper1540", "life181" };

        var right_scion_socket_ids = new List<string> { "attack_speed1285", "mana_regeneration1276", "minion_mana2637_", "accuracy_rating2345", "area_of_effect_radius1061", "mastery_reservation210", "evasion537", "reduced_mana_reservation1552", "evasion536", "cast_speed1547", "movement_speed1155", "spell_damage1293", "energy_shield403", "energy_shield298", "attack_speed1279", "mine_damage2149", "intelligence897", "mastery_energyshield100", "life_on_kill1755", "path_of_the_hunter1539", "evasion538", "cast_speed1546", "conduit1135", "mastery_miniondefence182", "attack_speed1287", "attack_speed1286", "dexterity846", "critical_notable1770", "fire_resistance1288", "harrier1542", "critical_strike_chance1298", "mastery_criticals66", "movement_speed1017", "path_of_the_savant1538", "accuracy_rating2347", "mana389", "life_regeneration1085", "mastery_life144", "projectile_damage1295", "critical_strike_chance1299", "energy_shield296", "projectile_damage1294", "minion_mana_notable2638", "spell_damage1291", "intelligence881", "spell_damage1277", "mana390", "jewel_slot1967", "melee_damage1281", "life_on_kill_notable1757", "accuracy_rating2346", "mastery_evasion108", "area_of_effect_radius1062", "dexterity841", "life1280", "spell_damage1292", "minion_mana2636", "mine_throwing_speed2651", "aura_effect1556", "energy_shield293", "evasion1011", "resilience_keystone2851_", "movement_speed1018", "life_on_kill1756", "projectile_damage1278", "cast_speed1548", "leadership1201" };

        var center_scion_socket_ids = new List<string> { "attack_speed1285", "totem_attack_and_cast_speed1504", "mana_regeneration1276", "accuracy_rating2345", "reduced_duration_notable2742", "mana_on_damage_notable1737", "block1300", "evasion536", "movement_speed1155", "dexterity849", "mastery_life128", "path_of_the_warrior1537", "iron_grip1181", "life1164", "melee_damage1284", "reduced_duration2741", "life193", "attack_speed1279", "dexterity847", "mana_flasks1741", "melee_damage1283", "evasion1092", "sentinel1541", "path_of_the_hunter1539", "life1406", "block1301", "mana_flasks_notable1743", "mana768", "skill_duration1036", "projectile_damage1296", "skill_duration437", "mastery_mana169", "totem_life_and_duration1503", "attack_speed1286", "strength789", "mastery_duration91", "jewel_slot1963", "reflexes706", "fire_resistance1288", "curse_alternate_notable2807", "movement_speed1017", "lightning_resistance1290", "cold_resistance1289", "mana389", "life_regeneration1085", "projectile_damage1295", "mana_flasks1740", "projectile_damage1294", "mastery_mana167", "block1302", "strength773", "spell_damage1277", "melee_damage1281", "accuracy_rating2346", "mastery_evasion108", "reduced_duration2740", "skill_duration_notable1738", "life1280", "life_regeneration1087", "deaden_keystone2849", "spell_damage1292", "mana767", "evasion1011", "movement_speed1018", "projectile_damage1278", "melee_damage1282", "totem_placement_speed_notable1509", "mastery_totem235", "life184" };

        var supreme_ego_socket_ids = new List<string> { "accuracy581", "shield_damage2559", "dagger_poison2529", "dexterity981", "evasion_and_energy_shield1426", "intelligence957", "aura_effect_reservation_cost_notable1558", "trap_damage_additional_traps_notable1524", "dexterity855", "critical_dot_mult_notable2664", "strength815", "elemental_damage_es1615", "mastery_trap237", "dagger_poison2530", "mastery_chaos47", "trap_laying_speed_and_damage1521", "critical_chance2265", "dexterity1989", "adder's_touch443", "mastery_charges53", "jewel_slot1958", "trap_damage1510", "chaos_damage1579", "dexterity995", "critical_ailment_dot_multiplier2666", "dexterity851", "mastery_attack18", "projectile_damage1485", "projectile_damage592", "shield_damage2560", "elemental_reflect_2794", "mastery_trap240", "dagger_leech_notable2537", "life1115", "dexterity977", "frenzy_charge_on_kill2153", "supreme_ego_keystone2696", "dexterity848", "elemental_reflect_notable_2796", "life1117", "mastery_reservation208", "elemental_reflect_2795", "chaos_damage1578", "dexterity990", "mastery_damageovertime84", "channelling_notable2282", "projectile_damage593", "mastery_dagger79", "reduced_mana_reservation1199", "dexterity992", "aura_area_of_effect1203", "dagger_poison2528", "attack_speed1488" };

        var duelist_socket_ids = new List<string> { "golem's_blood1088", "dual_wield_damage1859", "shield_block35", "dual_wield_speed567", "maximum_endurance_charges133", "totem_attack_damage2676", "dexterity840", "armour_guards_2378", "poison_bleed_chance_2179", "strength1984", "melee_physical_damage_with_shield1854", "mana_on_kill_notable1704", "dexterity838", "dexterity987", "mana_on_kill1475", "armour_and_evasion1454", "dexterity1990_", "stances_notable2758_", "mastery_evasion115", "defences_with_shield1857", "leather_and_steel1458", "dual_wield_damage622", "maximum_frenzy_charges527", "strength1005", "dual_wield_damage621", "melee_physical_damage_with_shield1856", "dervish1028", "mace_damage_and_armour1568", "mastery_attack13", "two_hand_crit2539", "life1196", "projectile_damage1860", "two_hand_damage1862", "life1213", "stances2757", "two_hand_crit_notable2542", "strength1004", "executioner648", "warcry_empowered_notable2713", "mastery_warcry251", "warcry_empowered2712", "projectile_damage1131", "two_handed_attack_speed649", "endurance_charge_duration2003", "stances2756", "mastery_twohand245_", "two_hand_damage1861", "two_handed_damage646", "shield_block33", "poison_bleed_duration_2180", "mastery_armour11", "melee_physical_damage_with_shield1855", "projectile_damage1271", "life_armour_evasion_notable1853", "mastery_mana171", "armour_and_evasion1453", "armour_guards_2379", "armour_guards_notable_2380", "melee_physical_damage_with_shield_notable1858", "frenzy_charge_duration2006", "projectile_damage1130", "jewel_slot1975", "totem_attack_damage2677", "strength1983", "mastery_damageovertime82", "mace_damage77", "mana_on_kill1476", "two_hand_crit2541", "poison_bleed_notable_2181", "fury_bolts1132", "mastery_life138", "warcry_empowered2710", "warcry_empowered2711" };

        var shadow_socket_ids = new List<string> { "mastery_life135", "mastery_energyshield106", "chaos_resist1580", "life_evasion_energy_shield2293", "frenzy_charge_duration531", "power_charge_duration2000", "claw_damage274", "dexterity991", "mastery_leech127", "mastery_dagger76", "projectile_damage_projectile_speed1628", "damage_area_projectile_speed_2297", "dagger_global_crit_notable2527", "mastery_mana164", "evasion_and_energy_shield14ion746", "mastery_curse75", "wandslinger's_prowess232", "deep_thoughts383", "golem2640", "mastery_minionoffence191_", "mastery_mace157", "lord_of_the_dead1122", "mana386", "lightning_damage312", "mastery_staff220", "herald_notable2726", "herald_reservation2723", "lightning_damage315", "cold_damage1659", "cold_damage360", "intensify_notable2777", "heart_of_the_panther994", "mastery_reservation206", "staff_spells2311", "curse_area1672", "chill_duration365", "staff_spells_and_block2318", "mana_spell_damage2608", "intelligence934", "shock_duration222", "mana1623", "staff_spells_and_block2317", "lightning_damage313", "wand_damage_and_accuracy243", "mana_spell_block2610", "herald_reservation2722", "mastery_mana158", "intelligence1996", "freeze_chance1650", "lightning_damage317", "spell_damage1868", "mastery_wand249", "spell_damage_per_power_charge217", "lightning_damage318", "mastery_lightning149", "mastery_cold59", "mana399", "herald_effect2724", "shock_chance1653", "jewel_slot1972", "fire_damage1103", "herald_effect2725", "wand_damage245" };
        var templar_socket_ids = new List<string> { "life1209", "elemental_and_physical_damage2284", "elemental_damage_and_elemental_penetration2287", "life1210", "intelligence888", "maximum_endurance_charges132", "physical_and_elemental_damage_2223", "strength1001", "sigil_damage_and_activation_range2262", "sigil_frequency_and_duration2263", "the_agnostic_keystone2695", "physical_and_elemental_damage_2221", "sigil_notable2264", "mana_arcane_surge2587", "strength824", "jewel_slot1977", "intelligence917", "power_charge_duration1998", "mana_arcane_surge2589", "elemental_damage1905", "intelligence1995", "mastery_energyshield107", "elemental_and_physical_damage2285", "strength1980", "maximum_power_charges299", "body_and_soul1173", "fitness1186", "intelligence1992", "mastery_brand38", "armour_and_energy_shield1178", "endurance_charge_duration153", "sigil_damage2260", "damage_and_minion_damage2228", "elemental_damage_and_ailment_effect_and_burning_damage2288", "mastery_life136", "mastery_elemental93", "mastery_mana160", "armour_and_energy_shield1450", "staff_damage57", "mana_arcane_surge_notable2590", "sigil_damage_and_activation_range2261", "elemental_damage1906", "mana_arcane_surge2588_", "strength811" };

        var witch_top_socket_ids = new List<string> { "intelligence902", "spell_damage1867", "curse_cast_speed1674", "intelligence895", "cold_damage358", "staff_spells_and_block_notable2342", "power_charge_duration1999", "ignite_duration1796", "mana_spell_damage_notable2609", "intelligence896", "mana_spell_damage_block2613", "mastery_mana162", "intelligence1994", "golem2639", "curse_effect_notable1669", "mana_spell_block_notable2611", "intelligence929", "intelligence101", "maximum_power_charges742", "mana_regeneration746", "mastery_curse75", "wandslinger's_prowess232", "deep_thoughts383", "golem2640", "mastery_minionoffence191_", "mastery_mace157", "lord_of_the_dead1122", "mana386", "lightning_damage312", "mastery_staff220", "herald_notable2726", "herald_reservation2723", "lightning_damage315", "cold_damage1659", "cold_damage360", "intensify_notable2777", "heart_of_the_panther994", "mastery_reservation206", "staff_spells2311", "curse_area1672", "chill_duration365", "staff_spells_and_block2318", "mana_spell_damage2608", "intelligence934", "shock_duration222", "mana1623", "staff_spells_and_block2317", "lightning_damage313", "wand_damage_and_accuracy243", "mana_spell_block2610", "herald_reservation2722", "mastery_mana158", "intelligence1996", "freeze_chance1650", "lightning_damage317", "spell_damage1868", "mastery_wand249", "spell_damage_per_power_charge217", "lightning_damage318", "mastery_lightning149", "mastery_cold59", "mana399", "herald_effect2724", "shock_chance1653", "jewel_slot1972", "fire_damage1103", "herald_effect2725", "wand_damage245" };
        var witch_left_socket_ids = new List<string> { "cast_speed419", "intelligence918", "energy_shield1465", "intelligence891", "minion_duration_notable2626", "mastery_staff223", "savant901", "dexterity869", "intelligence889", "minion_duration2625", "spell_damage725", "mana397", "mastery_flask125", "cast_speed420", "life_mana_notable1730", "spell_damage723", "minion_duration2624_", "strength828", "mana_shield1544", "energy_shield1466", "mastery_minionoffence186", "intelligence920", "jewel_slot1957", "spell_damage724", "intelligence922", "mana388", "mana_mana_flask2615", "mastery_life147", "intelligence883", "mana_mana_flask_notable2616", "intelligence882", "mana_mana_flask2614" };
        var witch_right_socket_ids = new List<string> { "shield_damage2561", "cast_speed417", "intelligence905", "mastery_minionoffence190", "nimbleness412", "intelligence956", "cast_speed416", "mastery_resistance262", "life_es_notable1769", "strength702", "intelligence908", "mastery_life140", "dexterity836", "pain_attunement1178", "intelligence907", "corpses_life2745", "intelligence887", "mastery_caster44", "jewel_slot1959", "intelligence941", "minion_life1151", "minion_life281", "intelligence946", "channelling_damage2277", "life_es1766", "channelling_damage2276", "life_es1768", "channelling_damage_and_speed2279", "life_es1767" };



        var testJewel = new TestJewel();

        testJewel.ProcessIds("left_scion_socket", left_scion_socket_ids, "glorious_left_scion_socket.txt");
        testJewel.ProcessIds("right_scion_socket", right_scion_socket_ids, "glorious_right_scion_socket.txt");
        testJewel.ProcessIds("center_scion_socket", center_scion_socket_ids, "glorious_center_scion_socket.txt");
        testJewel.ProcessIds("supreme_ego_socket", supreme_ego_socket_ids, "glorious_supreme_ego_socket.txt");
        testJewel.ProcessIds("duelist_socket", duelist_socket_ids, "glorious_duelist_socket.txt");
        testJewel.ProcessIds("shadow_socket", shadow_socket_ids, "glorious_shadow_socket.txt");
        testJewel.ProcessIds("templar_socket", templar_socket_ids, "glorious_templar_socket.txt");
        testJewel.ProcessIds("witch_top_socket", witch_top_socket_ids, "glorious_witch_top_socket.txt");

        testJewel.ProcessIds("witch_left_socket_ids", witch_left_socket_ids, "glorious_witch_left_socket.txt");
        testJewel.ProcessIds("witch_right_socket_ids", witch_right_socket_ids, "glorious_witch_right_socket.txt");








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
