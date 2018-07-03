public abstract class Animal
{
    protected Animal(string name, int age)
    {
        Name = name;
        Age = age;
        this.CleansingStatus = "UNCLEANSED";
    }

    public string Name { get; protected set; }

    public int Age { get; protected set; }

    public string CleansingStatus { get; set; }
}