using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PawManager
{
    private List<Center> centers;
    private List<Animal> addoptedAnimals;
    private List<Animal> cleansedAnimals;
    private Dictionary<string, int> information;

    public PawManager()
    {
        this.centers = new List<Center>();
        this.addoptedAnimals = new List<Animal>();
        this.cleansedAnimals = new List<Animal>();
        this.information = new Dictionary<string, int>();
    }

    public void RegisterCleansingCenter(List<string> args)
    {
        try
        {
            var name = args[0];

            var center = new CleansingCenter(name);

            centers.Add(center);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void RegisterAdoptionCenter(List<string> args)
    {
        try
        {
            var name = args[0];

            var center = new AdoptionCenter(name);

            centers.Add(center);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void RegisterDog(List<string> args)
    {
        var name = args[0];
        var age = int.Parse(args[1]);
        var learnedCommands = int.Parse(args[2]);
        var adoptionCenterName = args[3];

        var dog = new Dog(name, age, learnedCommands);
        var center = centers.SingleOrDefault(x => x.Name == adoptionCenterName);
        center.Animals.Add(dog);
    }

    public void RegisterCat(List<string> args)
    {
        var name = args[0];
        var age = int.Parse(args[1]);
        var intelligenceCoefficient = int.Parse(args[2]);
        var adoptionCenterName = args[3];

        var cat = new Cat(name, age, intelligenceCoefficient);
        var center = centers.SingleOrDefault(x => x.Name == adoptionCenterName);
        center.Animals.Add(cat);
    }

    public void SendForCleansing(List<string> args)
    {
        var adoptionCenter = centers.SingleOrDefault(x => x.Name == args[0]);
        var cleansingCenter = centers.SingleOrDefault(x => x.Name == args[1]);

        cleansingCenter.Animals.AddRange(adoptionCenter.Animals.Where(x => x.CleansingStatus == "UNCLEANSED"));


        if (!information.ContainsKey(args[0]))
        {
            information[args[0]] = 0;
        }

        information[args[0]] += adoptionCenter.Animals.Count(x => x.CleansingStatus == "UNCLEANSED");

        if (adoptionCenter.Animals.Any(x => x.CleansingStatus == "UNCLEANSED"))
        {
            adoptionCenter.Animals.RemoveAll(x => x.CleansingStatus == "UNCLEANSED");
        }
    }

    public void Cleanse(List<string> args)
    {
        var cleansingCenter = centers.SingleOrDefault(x => x.Name == args[0]);
        while (information.Count > 0)
        {
            var adoptionCenter = centers.SingleOrDefault(x => x.Name == information.First().Key);
            var animalsCount = information.First().Value;

            var toCleanse = cleansingCenter.Animals.Take(animalsCount).ToList();

            foreach (var animal in toCleanse)
            {
                animal.CleansingStatus = "CLEANSED";
                cleansedAnimals.Add(animal);
                adoptionCenter.Animals.Add(animal);
            }

            information.Remove(information.First().Key);
            cleansingCenter.Animals.RemoveRange(0, animalsCount);
        }

        cleansingCenter.Animals.Clear();
    }

    public void Adopt(List<string> args)
    {
        var centerName = args[0];

        var center = centers.SingleOrDefault(x => x.Name == centerName);

        foreach (var animal in center.Animals.Where(x => x.CleansingStatus == "CLEANSED"))
        {
            addoptedAnimals.Add(animal);
        }

        if (center.Animals.Any(x => x.CleansingStatus == "CLEANSED"))
        {
            center.Animals.RemoveAll(x => x.CleansingStatus == "CLEANSED");
        }
    }


    public string Paw()
    {
        var sb = new StringBuilder();

        var animalsWaitingAdoption = default(int);
        var animalsWaitingCleansing = default(int);

        foreach (var center in centers)
        {
            foreach (var animal in center.Animals)
            {
                if (animal.CleansingStatus == "UNCLEANSED" && center.GetType().Name != "AdoptionCenter")
                {
                    animalsWaitingCleansing++;
                }
                else if (animal.CleansingStatus == "CLEANSED")
                {
                    animalsWaitingAdoption++;
                }
            }
        }

        var adoptedAnimals = addoptedAnimals.Count > 0
            ? string.Join(", ", addoptedAnimals.OrderBy(x => x.Name).Select(x => x.Name))
            : "None";
        var cleanseAnimals = cleansedAnimals.Count > 0
            ? string.Join(", ", cleansedAnimals.OrderBy(x => x.Name).Select(x => x.Name))
            : "None";


        sb.AppendLine("Paw Incorporative Regular Statistics")
            .AppendLine($"Adoption Centers: {centers.Count(x => x.GetType().Name == "AdoptionCenter")}")
            .AppendLine($"Cleansing Centers: {centers.Count(x => x.GetType().Name == "CleansingCenter")}")
            .AppendLine(
                $"Adopted Animals: {adoptedAnimals}")
            .AppendLine(
                $"Cleansed Animals: {cleanseAnimals}")
            .AppendLine(
                $"Animals Awaiting Adoption: {animalsWaitingAdoption}")
            .AppendLine(
                $"Animals Awaiting Cleansing: {animalsWaitingCleansing}");

        return sb.ToString().Trim();
    }
}