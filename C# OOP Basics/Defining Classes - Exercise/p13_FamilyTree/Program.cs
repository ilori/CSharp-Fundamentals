using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var input = Console.ReadLine().Split();

        var familyTree = new List<Person>();

        if (input.Length == 1)
        {
            var birthDate = input[0];

            familyTree.Add(new Person()
            {
                BirthDate = birthDate
            });
        }
        else if (input.Length == 2)
        {
            var firstName = input[0];
            var lastName = input[1];

            familyTree.Add(new Person()
            {
                FirstName = firstName,
                LastName = lastName
            });
        }

        var command = Console.ReadLine();

        while (command != "End")
        {
            var tokens = command.Split(new[] {" ", "-"}, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (tokens.Count == 2)
            {
                if (!familyTree.Any(p => p.BirthDate == tokens[0]))
                {
                    var birthDate = tokens[0];

                    familyTree.Add(new Person()
                    {
                        BirthDate = birthDate
                    });
                }

                var parent = familyTree.FirstOrDefault(p => p.BirthDate == tokens[0]);

                if (!familyTree.Any(p => p.BirthDate == tokens[1]))
                {
                    var birthDate = tokens[1];

                    familyTree.Add(new Person()
                    {
                        BirthDate = birthDate
                    });
                }

                var child = familyTree.FirstOrDefault(p => p.BirthDate == tokens[1]);

                parent.Children.Add(child);

                child.Parents.Add(parent);
            }
            else if (tokens.Count == 3)
            {
                if (command.Contains("-"))
                {
                    if (char.IsDigit(tokens[0][0]))
                    {
                        if (!familyTree.Any(p => p.BirthDate == tokens[0]))
                        {
                            var birthDate = tokens[0];

                            familyTree.Add(new Person()
                            {
                                BirthDate = birthDate
                            });
                        }

                        var parent = familyTree.FirstOrDefault(p => p.BirthDate == tokens[0]);

                        if (!familyTree.Any(p => p.FirstName == tokens[1] && p.LastName == tokens[2]))
                        {
                            var firstName = tokens[1];
                            var lastName = tokens[2];
                            familyTree.Add(new Person()
                            {
                                FirstName = firstName,
                                LastName = lastName
                            });
                        }

                        var child = familyTree.FirstOrDefault(p =>
                            p.FirstName == tokens[1] && p.LastName == tokens[2]);
                        
                        parent.Children.Add(child);

                        child.Parents.Add(parent);
                    }
                    else if (char.IsDigit(tokens[2][0]))
                    {
                        if (!familyTree.Any(p => p.BirthDate == tokens[2]))
                        {
                            var birthDate = tokens[2];

                            familyTree.Add(new Person()
                            {
                                BirthDate = birthDate
                            });
                        }

                        var child = familyTree.FirstOrDefault(p => p.BirthDate == tokens[2]);

                        if (!familyTree.Any(p => p.FirstName == tokens[0] && p.LastName == tokens[1]))
                        {
                            var firstName = tokens[0];
                            var lastName = tokens[1];
                            familyTree.Add(new Person()
                            {
                                FirstName = firstName,
                                LastName = lastName
                            });
                        }

                        var parent =
                            familyTree.FirstOrDefault(p => p.FirstName == tokens[0] && p.LastName == tokens[1]);
                        
                        parent.Children.Add(child);

                        child.Parents.Add(parent);
                    }
                }
                else
                {
                    var persons = familyTree.Where(p =>
                        (p.FirstName == tokens[0] && p.LastName == tokens[1]) || p.BirthDate == tokens[2]);

                    var children = new List<Person>();
                    var parents = new List<Person>();

                    foreach (var person in persons)
                    {
                        children.AddRange(person.Children);
                        parents.AddRange(person.Parents);
                    }

                    foreach (var person in persons)
                    {
                        person.FirstName = tokens[0];
                        person.LastName = tokens[1];
                        person.BirthDate = tokens[2];
                        person.Children = children;
                        person.Parents = parents;
                    }
                }
            }
            else if (tokens.Count == 4)
            {
                if (!familyTree.Any(p => p.FirstName == tokens[0] && p.LastName == tokens[1]))
                {
                    var firstName = tokens[0];
                    var lastName = tokens[1];
                    familyTree.Add(new Person()
                    {
                        FirstName = firstName,
                        LastName = lastName
                    });
                }

                var parent = familyTree.FirstOrDefault(p => p.FirstName == tokens[0] && p.LastName == tokens[1]);

                if (!familyTree.Any(p => p.FirstName == tokens[2] && p.LastName == tokens[3]))
                {
                    var firstName = tokens[2];
                    var lastName = tokens[3];

                    familyTree.Add(new Person()
                    {
                        FirstName = firstName,
                        LastName = lastName
                    });
                }

                var child = familyTree.FirstOrDefault(p => p.FirstName == tokens[2] && p.LastName == tokens[3]);
                
                parent.Children.Add(child);

                child.Parents.Add(parent);
            }

            command = Console.ReadLine();
        }

        if (input.Length == 1)
        {
            var personToPrint = familyTree.FirstOrDefault(p => p.BirthDate == input[0]);
            Console.WriteLine(personToPrint);
        }
        else if (input.Length == 2)
        {
            var personToPrint = familyTree.FirstOrDefault(p => p.FirstName == input[0] && p.LastName == input[1]);
            Console.WriteLine(personToPrint);
        }
    }
}