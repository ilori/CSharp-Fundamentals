using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var soldiers = new List<ISoldier>();

        var input = Console.ReadLine();

        while (input != "End")
        {
            var tokens = input.Split().ToArray();
            var id = int.Parse(tokens[1]);
            var firstName = tokens[2];
            var lastName = tokens[3];
            var salary = double.Parse(tokens[4]);

            try
            {
                ISoldier soldier;
                switch (tokens[0])
                {
                    case "Private":
                        soldier = new Private(id, firstName, lastName, salary);
                        break;
                    case "LeutenantGeneral":
                        var leutenant = new LeutenantGeneral(id, firstName, lastName, salary);
                        for (var i = 5; i < tokens.Length; i++)
                        {
                            var @private = soldiers.First(x => x.Id == int.Parse(tokens[i]));

                            leutenant.AddPrivate(@private);
                        }

                        soldier = leutenant;
                        break;
                    case "Engineer":
                        var engCorps = tokens[5];
                        var engineer = new Engineer(id, firstName, lastName, salary, engCorps);
                        for (var i = 6; i < tokens.Length; i++)
                        {
                            var partName = tokens[i];
                            var hoursWorked = int.Parse(tokens[++i]);
                            var repair = new Repair(partName, hoursWorked);
                            engineer.AddRepair(repair);
                        }

                        soldier = engineer;
                        break;
                    case "Commando":
                        var comCorps = tokens[5];
                        var commando = new Commando(id, firstName, lastName, salary, comCorps);
                        for (var i = 6; i < tokens.Length; i++)
                        {
                            var codeName = tokens[i];
                            var missionState = tokens[++i];
                            try
                            {
                                var mission = new Mission(codeName, missionState);
                                commando.AddMission(mission);
                            }
                            catch
                            {
                            }
                        }

                        soldier = commando;
                        break;
                    case "Spy":
                        var codeNumber = (int) salary;
                        soldier = new Spy(id, firstName, lastName, codeNumber);
                        break;
                    default:
                        throw new ArgumentException("Invalid soldier type");
                }


                soldiers.Add(soldier);
                input = Console.ReadLine();
            }
            catch
            {
                input = Console.ReadLine();
            }
        }

        foreach (var soldier in soldiers)
        {
            Console.WriteLine(soldier);
        }
    }
}