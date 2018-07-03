namespace p01_GenericBox
{
    using System;

    public class Program
    {
        public static void Main()
        {
            Box<double> box = new Box<double>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                double element = double.Parse(Console.ReadLine());

                box.Add(element);
            }

            Console.WriteLine(box.CompareTo(double.Parse(Console.ReadLine())));
        }
    }
}