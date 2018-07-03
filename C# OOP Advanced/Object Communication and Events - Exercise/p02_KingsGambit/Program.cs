namespace p02_KingsGambit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            string kingName = Console.ReadLine();

            King king = new King(kingName);

            List<Figure> figures = new List<Figure>();

            string[] guards = Console.ReadLine().Split();
            string[] footmens = Console.ReadLine().Split();

            foreach (var name in guards)
            {
                Figure royalGuard = new RoyalGuard(name);

                figures.Add(royalGuard);

                king.KingUnderAttack += royalGuard.KingUnderAttack;
            }

            foreach (var name in footmens)
            {
                Figure footman = new Footman(name);

                figures.Add(footman);

                king.KingUnderAttack += footman.KingUnderAttack;
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split();

                string command = tokens[0];

                switch (command)
                {
                    case "Kill":
                        string soldierName = tokens[1];

                        Figure soldier = figures.FirstOrDefault(s => s.Name == soldierName);

                        king.KingUnderAttack -= soldier.KingUnderAttack;

                        figures.Remove(soldier);

                        break;
                    case "Attack":
                        king.OnKingAttack();
                      
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}