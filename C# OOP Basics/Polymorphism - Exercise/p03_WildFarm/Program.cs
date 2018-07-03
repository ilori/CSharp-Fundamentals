using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var animals = new List<IAnimal>();

        while (true)
        {
            var animalTokens = Console.ReadLine().Split().ToList();
            if (animalTokens[0] == "End")
            {
                break;
            }

            var animalType = animalTokens[0];
            IAnimal animal = null;

            switch (animalType)
            {
                case "Cat":
                    animal = new Cat(animalTokens[1], double.Parse(animalTokens[2]), animalTokens[3],
                        animalTokens[4]);
                    Console.WriteLine(animal.ProduceSound());
                    break;
                case "Dog":
                    animal = new Dog(animalTokens[1], double.Parse(animalTokens[2]), animalTokens[3]);
                    Console.WriteLine(animal.ProduceSound());
                    break;
                case "Hen":
                    animal = new Hen(animalTokens[1], double.Parse(animalTokens[2]), double.Parse(animalTokens[3]));
                    Console.WriteLine(animal.ProduceSound());
                    break;
                case "Mouse":
                    animal = new Mouse(animalTokens[1], double.Parse(animalTokens[2]), animalTokens[3]);
                    Console.WriteLine(animal.ProduceSound());
                    break;
                case "Owl":
                    animal = new Owl(animalTokens[1], double.Parse(animalTokens[2]), double.Parse(animalTokens[3]));
                    Console.WriteLine(animal.ProduceSound());
                    break;
                case "Tiger":
                    animal = new Tiger(animalTokens[1], double.Parse(animalTokens[2]), animalTokens[3],
                        animalTokens[4]);
                    Console.WriteLine(animal.ProduceSound());
                    break;
            }

            animals.Add(animal);

            var foodTokens = Console.ReadLine().Split().ToList();
            if (foodTokens[0] == "End")
            {
                break;
            }

            var foodName = foodTokens[0];
            var foodQuantity = int.Parse(foodTokens[1]);

            IFood food = null;

            switch (foodName)
            {
                case "Fruit":
                    food = new Fruit(foodQuantity);
                    break;
                case "Meat":
                    food = new Meat(foodQuantity);
                    break;
                case "Seeds":
                    food = new Seeds(foodQuantity);
                    break;
                case "Vegetable":
                    food = new Vegetable(foodQuantity);
                    break;
            }

            try
            {
                animal.EatFood(food);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }
}