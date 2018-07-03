namespace p01_KeyRevolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var bulletPrice = int.Parse(Console.ReadLine());

            var barrelSize = int.Parse(Console.ReadLine());

            var bullets = new Stack<int>(Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            var locks = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            var intelligenceValue = int.Parse(Console.ReadLine());

            var currentBullets = default(int);

            var bulletsSize = bullets.Count;
            while (locks.Count > 0 && bullets.Count > 0)
            {
                var bullet = bullets.Pop();


                for (var i = 0; i < 1; i++)
                {
                    if (bullet > locks[i])
                    {
                        Console.WriteLine($"Ping!");
                    }
                    else
                    {
                        locks.RemoveAt(i);
                        Console.WriteLine($"Bang!");
                    }
                }

                currentBullets++;

                if (currentBullets == barrelSize && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    currentBullets = default(int);
                }
            }

            if (bullets.Count >= 0 && locks.Count == 0)
            {
                bulletsSize -= bullets.Count;
                var totalBulletPrice = bulletsSize * bulletPrice;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue - totalBulletPrice}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}