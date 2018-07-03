namespace p01_EventImplementation
{
    using System;

    public class Program
    {
        public static void Main()
        {
            Dispatcher dispatcher = new Dispatcher();

            Handler handler = new Handler();

            dispatcher.NameChange += handler.OnDispatcherNameChange;

            string input = Console.ReadLine();

            while (input != "End")
            {
                string name = input;

                dispatcher.Name = name;

                input = Console.ReadLine();
            }
        }
    }
}