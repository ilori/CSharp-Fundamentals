namespace p11_ParkingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        private static Dictionary<int, HashSet<int>> parking = new Dictionary<int, HashSet<int>>();
        private static StringBuilder sb = new StringBuilder();

        public static void Main()
        {
            EnterTheParkingLot();
        }

        private static void EnterTheParkingLot()
        {
            var parkingSize = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var cols = parkingSize[1];

            var input = Console.ReadLine();

            while (input != "stop")
            {
                CommandParser(input, cols);

                input = Console.ReadLine();
            }

            Console.WriteLine(sb.ToString().Trim());
        }

        private static void CommandParser(string input, int cols)
        {
            var tokens = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var entryRow = tokens[0];
            var destinationRow = tokens[1];
            var destinationCol = tokens[2];

            ParkTheCar(entryRow, destinationRow, destinationCol, cols);
        }

        private static void ParkTheCar(int entryRow, int destinationRow, int destinationCol, int cols)
        {
            var parkingSpot = default(int);

            if (!IsThereFreeSpot(destinationRow, destinationCol))
            {
                parkingSpot = destinationCol;
            }
            else
            {
                for (int i = 1; i < cols - 1; i++)
                {
                    if (destinationCol - i > 0 &&
                        !IsThereFreeSpot(destinationRow, destinationCol - i))
                    {
                        parkingSpot = (destinationCol - i);
                        break;
                    }

                    if (destinationCol + i < cols &&
                        !IsThereFreeSpot(destinationRow, destinationCol + i))
                    {
                        parkingSpot = destinationCol + i;
                        break;
                    }
                }
            }

            if (parkingSpot == 0)
            {
                sb.AppendLine($"Row {destinationRow} full");
            }
            else
            {
                parking[destinationRow].Add(parkingSpot);

                var steps = Math.Abs(entryRow - destinationRow) + 1 + parkingSpot;

                sb.AppendLine(steps.ToString());
            }
        }

        private static bool IsThereFreeSpot(int destinationRow, int destinationCol)
        {
            if (parking.ContainsKey(destinationRow))
            {
                if (parking[destinationRow].Contains(destinationCol))
                {
                    return true;
                }
            }
            else
            {
                parking[destinationRow] = new HashSet<int>();
            }

            return false;
        }
    }
}