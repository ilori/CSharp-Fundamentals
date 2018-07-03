namespace p10_PredicateParty_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static List<string> names;

        private const string SuccessMessage = "{0} are going to the party!";
        private const string FailedMessage = "Nobody is going to the party!";

        public static void Main()
        {
            names = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var input = Console.ReadLine();


            while (input != "Party!")
            {
                var tokens = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToList();

                var command = tokens[0];

                var predicate = tokens[1];

                var criteria = tokens[2];

                switch (command)
                {
                    case "Remove":
                        RemovePeople(predicate, criteria);
                        break;
                    case "Double":
                        DoublePeople(predicate, criteria);
                        break;
                }

                input = Console.ReadLine();
            }


            Console.WriteLine(names.Count > 0
                ? string.Format(SuccessMessage, string.Join(", ", names))
                : FailedMessage);
        }

        private static void DoublePeople(string predicate, string criteria)
        {
            var peopleToDouble = new List<string>();

            switch (predicate)
            {
                case "StartsWith":
                    peopleToDouble = names.FindAll(x => x.StartsWith(criteria));
                    names.AddRange(peopleToDouble);
                    break;
                case "EndsWith":
                    peopleToDouble = names.FindAll(x => x.EndsWith(criteria));
                    names.AddRange(peopleToDouble);
                    break;
                case "Length":
                    peopleToDouble = names.FindAll(x => x.Length == int.Parse(criteria));
                    names.AddRange(peopleToDouble);
                    break;
            }
        }

        private static void RemovePeople(string predicate, string criteria)
        {
            switch (predicate)
            {
                case "StartsWith":
                    names.RemoveAll(x => x.StartsWith(criteria));
                    break;
                case "EndsWith":
                    names.RemoveAll(x => x.EndsWith(criteria));
                    break;
                case "Length":
                    names.RemoveAll(x => x.Length == int.Parse(criteria));
                    break;
            }
        }
    }
}