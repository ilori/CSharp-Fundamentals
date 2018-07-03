using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class BlackBoxIntegerTests
{
    public static void Main()
    {
        string input = Console.ReadLine();

        Type type = typeof(BlackBoxInteger);

        BlackBoxInteger testClass = (BlackBoxInteger) Activator.CreateInstance(type, true);

        StringBuilder sb = new StringBuilder();

        while (input != "END")
        {
            string[] tokens = input.Split("_").ToArray();

            string methodName = tokens[0];

            int value = int.Parse(tokens[1]);

            type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic)
                .Invoke(testClass, new object[] {value});

            int currentValue = (int) type.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(testClass);

            sb.AppendLine(currentValue.ToString());

            input = Console.ReadLine();
        }

        Console.WriteLine(sb.ToString().Trim());
    }
}