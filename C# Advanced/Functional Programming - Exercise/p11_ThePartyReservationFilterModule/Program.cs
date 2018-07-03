namespace p11_ThePartyReservationFilterModule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        private static List<string> guests;

        private static List<string> beforeFilter;

        public static void Main()
        {
            guests = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var input = Console.ReadLine();


            beforeFilter = new List<string>(guests);

            while (input != "Print")
            {
                var tokens = input.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];
                var filterType = tokens[1];
                var filterParameter = tokens[2];

                FilterResults(command, filterType, filterParameter);

                input = Console.ReadLine();
            }

            var result = new StringBuilder();

            foreach (var person in guests)
            {
                if (person != string.Empty)
                {
                    result.Append(person + " ");
                }
            }

            Console.WriteLine(result);
        }

        private static void FilterResults(string command, string filterType, string parameter)
        {
            bool StartsPredicate(string s) => s.StartsWith(parameter);
            bool EndsPredicate(string s) => s.EndsWith(parameter);
            bool LengthPredicate(string s) => s.Length == int.Parse(parameter);
            bool ConstainsPredicate(string s) => s.Contains(parameter);

            if (command == "Add filter")
            {
                var toRemove = new List<string>();

                switch (filterType)
                {
                    case "Starts with":
                        toRemove = guests.FindAll(StartsPredicate);
                        break;

                    case "Ends with":
                        toRemove = guests.FindAll(EndsPredicate);
                        break;

                    case "Length":
                        toRemove = guests.FindAll(LengthPredicate);
                        break;

                    case "Contains":
                        toRemove = guests.FindAll(ConstainsPredicate);
                        break;
                }

                foreach (var person in toRemove)
                {
                    for (var i = 0; i < guests.Count; i++)
                    {
                        if (guests[i] == person)
                        {
                            guests[i] = string.Empty;
                        }
                    }
                }
            }
            else if (command == "Remove filter")
            {
                var toBeAddedBack = new List<string>();

                switch (filterType)
                {
                    case "Starts with":
                        toBeAddedBack = beforeFilter.FindAll(StartsPredicate);
                        break;

                    case "Ends with":
                        toBeAddedBack = beforeFilter.FindAll(EndsPredicate);
                        break;

                    case "Length":
                        toBeAddedBack = beforeFilter.FindAll(LengthPredicate);
                        break;

                    case "Contains":
                        toBeAddedBack = beforeFilter.FindAll(ConstainsPredicate);
                        break;
                }

                foreach (var person in toBeAddedBack)
                {
                    var index = beforeFilter.LastIndexOf(person);
                    guests[index] = person;
                }
            }
        }
    }
}