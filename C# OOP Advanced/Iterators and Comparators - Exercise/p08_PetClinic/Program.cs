namespace p08_PetClinic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Factories;

    public class Program
    {
        public static void Main()
        {
            List<Pet> pets = new List<Pet>();

            List<Clinic> clinics = new List<Clinic>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split().ToArray();

                string command = tokens[0];

                tokens = tokens.Skip(1).ToArray();

                Clinic clinic;

                switch (command)
                {
                    case "Create":

                        string type = tokens[0];

                        switch (type)
                        {
                            case "Pet":
                                pets.Add(PetFactory.CreatePet(tokens.Skip(1).ToArray()));

                                break;

                            case "Clinic":
                                try
                                {
                                    clinics.Add(ClinicFactory.CreateClinic(tokens.Skip(1).ToArray()));
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }

                                break;
                        }

                        break;

                    case "Add":

                        Pet pet = pets.SingleOrDefault(p => p.Name == tokens[0]);

                        clinic = clinics.Single(c => c.Name == tokens[1]);

                        try
                        {
                            Console.WriteLine(clinic.Add(pet));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;

                    case "Release":

                        clinic = clinics.Single(c => c.Name == tokens[0]);

                        Console.WriteLine(clinic.Release());

                        break;

                    case "HasEmptyRooms":

                        clinic = clinics.Single(c => c.Name == tokens[0]);

                        Console.WriteLine(clinic.HasEmptyRooms());

                        break;

                    case "Print":

                        clinic = clinics.Single(c => c.Name == tokens[0]);

                        if (tokens.Length == 1)
                        {
                            clinic.PrintAllRooms();
                        }
                        else if (tokens.Length == 2)
                        {
                            clinic.PrintSingleRoom(int.Parse(tokens[1]));
                        }

                        break;
                }
            }
        }
    }
}