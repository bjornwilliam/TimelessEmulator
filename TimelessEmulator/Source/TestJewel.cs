using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimelessEmulator.Data;
using TimelessEmulator.Data.Models;
using TimelessEmulator.Game;

namespace TimelessEmulator
{
    public  class TestJewel
    {




    public void ProcessIds(List<string> ids)
    {
            DataManager.Initialize();

            var xibaquaJewel = new TimelessJewelConqueror(1, 0);
            uint alternateTreeVersionIndex = 1;
            AlternateTreeVersion alternateTreeVersion = DataManager.AlternateTreeVersions.First(q => (q.Index == alternateTreeVersionIndex));





            var seedRange = (100, 8000);

            var auraEffects = new Dictionary<int, uint>();
            for (int i = 100; i <= 8000; i++)
            {
                uint aura_effect = 0;
                foreach (var id in ids)
                {
                    var timelessJewel = new TimelessJewel(alternateTreeVersion, xibaquaJewel, (uint)i);
                    PassiveSkill passiveSkill = DataManager.GetPassiveSkillByFuzzyValue(id);
                    if (passiveSkill == null) continue;
                    AlternateTreeManager alternateTreeManager = new AlternateTreeManager(passiveSkill, timelessJewel);

                    bool isPassiveSkillReplaced = alternateTreeManager.IsPassiveSkillReplaced();
                    if (isPassiveSkillReplaced == false) continue;
                    if (passiveSkill.IsJewelSocket == true) continue;
                    AlternatePassiveSkillInformation alternatePassiveSkillInformation = alternateTreeManager.ReplacePassiveSkill();

                    aura_effect += PrintAlternatePassiveAdditionInformations(alternatePassiveSkillInformation.AlternatePassiveAdditionInformations);

                }
                auraEffects[i] = aura_effect;

            }
            var sortedDict = from entry in auraEffects orderby entry.Value descending select entry;



            //var timelessJewel = new TimelessJewel(alternateTreeVersion, timelessJewelConqueror, timelessJewelSeed);

            //AlternateTreeManager alternateTreeManager = new AlternateTreeManager(passiveSkill, timelessJewel);

            //            bool isPassiveSkillReplaced = alternateTreeManager.IsPassiveSkillReplaced();

            //AlternatePassiveSkillInformation alternatePassiveSkillInformation = alternateTreeManager.ReplacePassiveSkill();

            //AnsiConsole.MarkupLine($"[green]Alternate Passive Skill[/]: [yellow]{alternatePassiveSkillInformation.AlternatePassiveSkill.Name}[/] ([yellow]{alternatePassiveSkillInformation.AlternatePassiveSkill.Identifier}[/])");

            //for (int i = 0; i < alternatePassiveSkillInformation.AlternatePassiveSkill.StatIndices.Count; i++)
            //{
            //    uint statIndex = alternatePassiveSkillInformation.AlternatePassiveSkill.StatIndices.ElementAt(i);
            //    uint statRoll = alternatePassiveSkillInformation.StatRolls.ElementAt(i).Value;

            //    AnsiConsole.MarkupLine($"\t\tStat [yellow]{i}[/] | [yellow]{DataManager.GetStatTextByIndex(statIndex)}[/] (Identifier: [yellow]{DataManager.GetStatIdentifierByIndex(statIndex)}[/], Index: [yellow]{statIndex}[/]), Roll: [yellow]{statRoll}[/]");
            //}

            //PrintAlternatePassiveAdditionInformations(alternatePassiveSkillInformation.AlternatePassiveAdditionInformations);
        }

        private static uint PrintAlternatePassiveAdditionInformations(IReadOnlyCollection<AlternatePassiveAdditionInformation> alternatePassiveAdditionInformations)
        {
            ArgumentNullException.ThrowIfNull(alternatePassiveAdditionInformations, nameof(alternatePassiveAdditionInformations));

            uint aura_effect = 0;

            foreach (AlternatePassiveAdditionInformation alternatePassiveAdditionInformation in alternatePassiveAdditionInformations)
            {
                //AnsiConsole.MarkupLine($"\t[green]Addition[/]: [yellow]{alternatePassiveAdditionInformation.AlternatePassiveAddition.Identifier}[/]");

                for (int i = 0; i < alternatePassiveAdditionInformation.AlternatePassiveAddition.StatIndices.Count; i++)
                {
                    uint statIndex = alternatePassiveAdditionInformation.AlternatePassiveAddition.StatIndices.ElementAt(i);
                    uint statRoll = alternatePassiveAdditionInformation.StatRolls.ElementAt(i).Value;
                    if (statIndex == 3840)
                    {
                        aura_effect += statRoll;
                    }

                    //AnsiConsole.MarkupLine($"\t\tStat [yellow]{i}[/] | [yellow]{DataManager.GetStatTextByIndex(statIndex)}[/] (Identifier: [yellow]{DataManager.GetStatIdentifierByIndex(statIndex)}[/], Index: [yellow]{statIndex}[/]), Roll: [yellow]{statRoll}[/]");
                }
            }
            return aura_effect;
        }
    }
}
