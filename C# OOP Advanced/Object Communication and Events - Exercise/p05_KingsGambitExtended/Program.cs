namespace p05_KingsGambitExtended
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class Program
    {
        public static void Main()
        {
            string kingName = Console.ReadLine();
            King king = new King(kingName);

            string[] guards = Console.ReadLine().Split();
            string[] footmans = Console.ReadLine().Split();

            foreach (var name in guards)
            {
                Figure royalGuard = new RoyalGuard(name);

                king.AddSoldier(royalGuard);
            }

            foreach (var name in footmans)
            {
                Figure footman = new Footman(name);

                king.AddSoldier(footman);
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

                        Figure soldier = king.Figures.FirstOrDefault(s => s.Name == soldierName);

                        soldier.TakeAttack();

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