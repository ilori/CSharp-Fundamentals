﻿public class Citizen : IBuyer
{
    public Citizen(string name, int age, string id, string birthdate)
    {
        Name = name;
        Age = age;
        Id = id;
        Birthdate = birthdate;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public string Id { get; set; }
    public string Birthdate { get; set; }

    public int Food { get; private set; }

    public void BuyFood()
    {
        Food += 10;
    }
}