namespace p12_InfernoIII
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var input = Console.ReadLine();
            var commands = new List<string>();

            while (input != "Forge")
            {
                var tokens = input.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];
                var filterType = tokens[1];
                var parameter = int.Parse(tokens[2]);

                switch (command)
                {
                    case "Exclude":
                        commands.Add(filterType + "," + parameter);
                        break;
                    case "Reverse":
                        if (commands.Contains(filterType + "," + parameter))
                        {
                            commands.Remove(filterType + "," + parameter);
                        }

                        break;
                }

                input = Console.ReadLine();
            }

            var markedNums = new List<int>();

            foreach (var c in commands)
            {
                var tokens = c.Split(',');
                var command = tokens[0];
                var parameter = int.Parse(tokens[1]);
                bool LeftOrRightCheck(int x, int y) => x + y == parameter;
                bool LeftAndRightCheck(int x, int y, int z) => x + y + z == parameter;

                var nums = new List<int>();

                switch (command)
                {
                    case "Sum Left":

                        nums = SumLeft(numbers, LeftOrRightCheck);
                        break;

                    case "Sum Right":

                        nums = SumRight(numbers, LeftOrRightCheck);
                        break;

                    case "Sum Left Right":

                        nums = SumLeftRight(numbers, LeftAndRightCheck);
                        break;
                }

                markedNums.AddRange(nums);
            }

            foreach (var num in markedNums)
            {
                numbers.Remove(num);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static List<int> SumLeft(List<int> gems, Func<int, int, bool> resultCheck)
        {
            var result = new List<int>();

            for (var i = 0; i < gems.Count; i++)
            {
                var leftNum = i == 0 ? 0 : gems[i - 1];

                var currentNum = gems[i];

                if (resultCheck(leftNum, currentNum))
                {
                    result.Add(currentNum);
                }
            }

            return result;
        }

        private static List<int> SumRight(List<int> gems, Func<int, int, bool> resultCheck)
        {
            var result = new List<int>();

            for (var i = 0; i < gems.Count; i++)
            {
                var rightNum = i == gems.Count - 1 ? 0 : gems[i + 1];

                var currentNum = gems[i];

                if (resultCheck(currentNum, rightNum))
                {
                    result.Add(currentNum);
                }
            }

            return result;
        }

        private static List<int> SumLeftRight(List<int> gems, Func<int, int, int, bool> resultCheck)
        {
            var result = new List<int>();

            for (var i = 0; i < gems.Count; i++)
            {
                var leftNum = i == 0 ? 0 : gems[i - 1];

                var rightNum = i == gems.Count - 1 ? 0 : gems[i + 1];

                var currentNum = gems[i];

                if (resultCheck(leftNum, currentNum, rightNum))
                {
                    result.Add(currentNum);
                }
            }

            return result;
        }
    }
}