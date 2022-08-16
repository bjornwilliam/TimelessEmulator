using CsvHelper;
using Newtonsoft.Json;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
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




    public void ProcessIds(string socketName, List<string> ids,string savePath)
    {
            DataManager.Initialize();

            var xibaquaJewel = new TimelessJewelConqueror(1, 0);
            uint alternateTreeVersionIndex = 1;
            AlternateTreeVersion alternateTreeVersion = DataManager.AlternateTreeVersions.First(q => (q.Index == alternateTreeVersionIndex));
            // Csv 
            //var writer = new StreamWriter(savePath);
            //var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            var records = new List<dynamic>();


            var listOfDicts = new List<Dictionary<string, dynamic>>();
            //var auraEffects = new Dictionary<int, uint>();
            for (int i = 100; i <= 8000; i++)
            {

                var jsonDict = new Dictionary<string, dynamic>();
                jsonDict["seed"] = i;
                jsonDict["socketName"] = socketName;
                jsonDict["passiveChangesList"] = new List<dynamic>();
                //record.Seed = i;
                foreach (var id in ids)
                {
                    var passiveDict = new Dictionary<string, dynamic>();
                    passiveDict["graphId"] = id;



                    var timelessJewel = new TimelessJewel(alternateTreeVersion, xibaquaJewel, (uint)i);
                    PassiveSkill passiveSkill = DataManager.GetPassiveSkillByFuzzyValue(id);
                    if (passiveSkill == null) continue;
                    AlternateTreeManager alternateTreeManager = new AlternateTreeManager(passiveSkill, timelessJewel);
                    bool isPassiveSkillReplaced = alternateTreeManager.IsPassiveSkillReplaced();
                    //AnsiConsole.MarkupLine($"\t[purple]Passive[/]: [yellow]{passiveSkill.Name} {isPassiveSkillReplaced.ToString()}[/]");

                    if (isPassiveSkillReplaced == false)
                    {
                        continue;
                    }
                    if (passiveSkill.IsJewelSocket == true) continue;
                    AlternatePassiveSkillInformation alternatePassiveSkillInformation = alternateTreeManager.ReplacePassiveSkill();


                    var alternatePassiveDict = new Dictionary<string, dynamic>();
                    for (int j = 0; j < alternatePassiveSkillInformation.AlternatePassiveSkill.StatIndices.Count; j++)
                    {
                        uint statIndex = alternatePassiveSkillInformation.AlternatePassiveSkill.StatIndices.ElementAt(j);
                        uint statRoll = alternatePassiveSkillInformation.StatRolls.ElementAt(j).Value;

                        string statText =  DataManager.GetStatTextByIndex(statIndex);
                        //DataManager.GetStatIdentifierByIndex(statIndex)
                        string statIdentifier = DataManager.GetStatIdentifierByIndex(statIndex);
                        if (alternatePassiveDict.ContainsKey(statIdentifier))
                        {
                            alternatePassiveDict[statIdentifier] += statRoll;
                        }
                        else
                        {
                            alternatePassiveDict[statIdentifier] = statRoll;
                        }
                        //AnsiConsole.MarkupLine($"\t\tStat [yellow]{i}[/] | [yellow]{DataManager.GetStatTextByIndex(statIndex)}[/] (Identifier: [yellow]{DataManager.GetStatIdentifierByIndex(statIndex)}[/], Index: [yellow]{statIndex}[/]), Roll: [yellow]{statRoll}[/]");
                    }
                    passiveDict["alternate"] = alternatePassiveDict;

                    var additionalPassiveDict = new Dictionary<string, dynamic>();
                    foreach (AlternatePassiveAdditionInformation alternatePassiveAdditionInformation in alternatePassiveSkillInformation.AlternatePassiveAdditionInformations)
                    {
                        //AnsiConsole.MarkupLine($"\t[green]Addition[/]: [yellow]{alternatePassiveAdditionInformation.AlternatePassiveAddition.Identifier}[/]");
                        for (int t = 0; t < alternatePassiveAdditionInformation.AlternatePassiveAddition.StatIndices.Count; t++)
                        {
                            uint statIndex = alternatePassiveAdditionInformation.AlternatePassiveAddition.StatIndices.ElementAt(t);
                            uint statRoll = alternatePassiveAdditionInformation.StatRolls.ElementAt(t).Value;
                            string statText = DataManager.GetStatTextByIndex(statIndex);
                            string statIdentifier = DataManager.GetStatIdentifierByIndex(statIndex);
                            if (additionalPassiveDict.ContainsKey(statIdentifier))
                            {
                                additionalPassiveDict[statIdentifier] += statRoll;
                            }
                            else
                            {
                                additionalPassiveDict[statIdentifier] = statRoll;
                            }
                            //AnsiConsole.MarkupLine($"\t\tStat [yellow]{i}[/] | [yellow]{DataManager.GetStatTextByIndex(statIndex)}[/] (Identifier: [yellow]{DataManager.GetStatIdentifierByIndex(statIndex)}[/], Index: [yellow]{statIndex}[/]), Roll: [yellow]{statRoll}[/]");
                        }
                    }
                    passiveDict["additions"] = additionalPassiveDict;

                    jsonDict["passiveChangesList"].Add(passiveDict);
                }
                listOfDicts.Add(jsonDict);
            }
            using (StreamWriter file = File.CreateText(savePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, listOfDicts);
            }
            //using (var writer = new StreamWriter(savePath))
            //using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            //{
            //    csv.WriteRecords(records);
            //}

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
                        if (statRoll > 4)
                        {
                            var debug = 5;
                        }
                        aura_effect += statRoll;
                    } 

                    //AnsiConsole.MarkupLine($"\t\tStat [yellow]{i}[/] | [yellow]{DataManager.GetStatTextByIndex(statIndex)}[/] (Identifier: [yellow]{DataManager.GetStatIdentifierByIndex(statIndex)}[/], Index: [yellow]{statIndex}[/]), Roll: [yellow]{statRoll}[/]");
                }
            }
            return aura_effect;
        }
    }
}
