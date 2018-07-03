namespace p04_HitList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var targetInfo = int.Parse(Console.ReadLine());

            var input = Console.ReadLine();

            var info = new Dictionary<string, Dictionary<string, string>>();

            while (input != "end transmissions")
            {
                var tokens = input.Split(new[] {"=", ":", ";"}, StringSplitOptions.RemoveEmptyEntries).ToList();

                var name = tokens[0];

                for (int i = 1; i < tokens.Count; i += 2)
                {
                    var key = tokens[i];
                    var value = tokens[i + 1];

                    if (!info.ContainsKey(name))
                    {
                        info[name] = new Dictionary<string, string>();
                    }

                    info[name][key] = value;
                }

                input = Console.ReadLine();
            }

            var kill = Console.ReadLine().Split().ToList();

            var nameToKill = kill[1];

            var index = default(int);

            Console.WriteLine($"Info on {nameToKill}:");
            
            foreach (var kvp in info.Where(x => x.Key == nameToKill))
            {
                foreach (var k in kvp.Value.OrderBy(x => x.Key))
                {
                    index += k.Key.Length;
                    index += k.Value.Length;
                    Console.WriteLine($"---{k.Key}: {k.Value}");
                }
            }

            if (index < targetInfo)
            {
                Console.WriteLine($"Info index: {index}");
                Console.WriteLine($"Need {Math.Abs(index - targetInfo)} more info.");
            }
            else
            {
                Console.WriteLine($"Info index: {index}");
                Console.WriteLine($"Proceed");
            }
        }
    }
}