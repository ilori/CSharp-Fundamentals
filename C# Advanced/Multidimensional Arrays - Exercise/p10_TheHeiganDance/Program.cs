namespace p10_TheHeiganDance
{
    using System;

    public class TheHeiganDance
    {
        public static void Main()
        {
            var player = new Player()
            {
                Position = new int[] {7, 7},
                PlayerTotalHealth = 18500,
                Damage = double.Parse(Console.ReadLine()),
                IsHitedByPlagueCloud = false
            };

            var heiganTotalHealth = 3000000d;
            var lastCastedSpell = string.Empty;

            while (true)
            {
                if (player.IsHitedByPlagueCloud)
                {
                    player.PlayerTotalHealth -= 3500;
                    player.IsHitedByPlagueCloud = false;
                }

                heiganTotalHealth -= player.Damage;

                if (player.PlayerTotalHealth <= 0 && heiganTotalHealth <= 0)
                {
                    BothAreDead(player, lastCastedSpell);
                    break;
                }

                if (player.PlayerTotalHealth <= 0)
                {
                    HeiganHasWon(heiganTotalHealth, player, lastCastedSpell);
                    break;
                }

                if (heiganTotalHealth <= 0)
                {
                    PlayerHasWon(player);
                    break;
                }


                var attackInformation = Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                lastCastedSpell = attackInformation[0];
                var row = int.Parse(attackInformation[1]);
                var col = int.Parse(attackInformation[2]);

                var playerRow = player.Position[0];
                var playerCol = player.Position[1];

                if (IsWallReached(playerRow, playerCol, row, col) &&
                    IsInsideSpellArea(player, row, col))
                {
                    switch (lastCastedSpell)
                    {
                        case "Cloud":
                            player.PlayerTotalHealth -= 3500;
                            player.IsHitedByPlagueCloud = true;
                            break;
                        case "Eruption":
                            player.PlayerTotalHealth -= 6000;
                            break;
                    }
                }

                if (player.PlayerTotalHealth <= 0 && heiganTotalHealth <= 0)
                {
                    BothAreDead(player, lastCastedSpell);
                    break;
                }

                if (player.PlayerTotalHealth <= 0)
                {
                    HeiganHasWon(heiganTotalHealth, player, lastCastedSpell);
                    break;
                }

                if (heiganTotalHealth <= 0)
                {
                    PlayerHasWon(player);
                    break;
                }
            }
        }

        private static void BothAreDead(Player player, string lastCastedSpell)
        {
            if (lastCastedSpell == "Cloud")
            {
                lastCastedSpell = "Plague Cloud";
            }

            Console.WriteLine($"Heigan: Defeated!");
            Console.WriteLine($"Player: Killed by {lastCastedSpell}");
            Console.WriteLine($"Final position: {player.Position[0]}, {player.Position[1]}");
        }

        private static void PlayerHasWon(Player player)
        {
            Console.WriteLine("Heigan: Defeated!");
            Console.WriteLine($"Player: {player.PlayerTotalHealth}");
            Console.WriteLine($"Final position: {player.Position[0]}, {player.Position[1]}");
        }

        private static void HeiganHasWon(double heiganTotalHealth, Player player, string lastCastedSpell)
        {
            if (lastCastedSpell == "Cloud")
            {
                lastCastedSpell = "Plague Cloud";
            }

            Console.WriteLine($"Heigan: {heiganTotalHealth:F2}");
            Console.WriteLine($"Player: Killed by {lastCastedSpell}");
            Console.WriteLine($"Final position: {player.Position[0]}, {player.Position[1]}");
        }


        private static bool IsInsideSpellArea(Player player, int row, int col)
        {
            if (player.Position[0] > 0 &&
                !IsWallReached(player.Position[0] - 1, player.Position[1], row, col))
            {
                player.Position[0]--;
                return false;
            }

            if (player.Position[1] + 1 < 15 &&
                !IsWallReached(player.Position[0], player.Position[1] + 1, row, col))
            {
                player.Position[1]++;
                return false;
            }

            if (player.Position[0] + 1 < 15 &&
                !IsWallReached(player.Position[0] + 1, player.Position[1], row, col))
            {
                player.Position[0]++;
                return false;
            }

            if (player.Position[1] > 0 &&
                !IsWallReached(player.Position[0], player.Position[1] - 1, row, col))
            {
                player.Position[1]--;
                return false;
            }

            return true;
        }

        private static bool IsWallReached(int playerRow, int playerCol, int row, int col)
        {
            return (playerRow >= row - 1) && (playerRow <= row + 1) && (playerCol >= col - 1) &&
                   (playerCol <= col + 1);
        }
    }
}