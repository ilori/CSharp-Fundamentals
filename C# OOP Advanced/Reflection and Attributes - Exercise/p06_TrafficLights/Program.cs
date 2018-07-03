using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Program
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split().ToArray();

        TrafficLight[] trafficLights = new TrafficLight[input.Length];

        for (int i = 0; i < trafficLights.Length; i++)
        {
            trafficLights[i] = (TrafficLight) Activator.CreateInstance(typeof(TrafficLight), input[i]);
        }

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            List<string> result = new List<string>();

            foreach (var trafficLight in trafficLights)
            {
                trafficLight.Update();

                FieldInfo field = typeof(TrafficLight).GetField("signal",
                    BindingFlags.NonPublic | BindingFlags.Instance);

                result.Add(field.GetValue(trafficLight).ToString());
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}