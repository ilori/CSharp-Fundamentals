public class Person
{
    public Person()
    {
        name = "No name";
        age = 1;
    }

    public Person(int age) : this()
    {
        this.age = age;
    }

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    private string name;
    private int age;

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}