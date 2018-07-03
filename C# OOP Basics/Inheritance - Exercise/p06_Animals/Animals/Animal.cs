using System;
using System.Text;

public abstract class Animal : ISoundProducable
{
    private string name;
    private int age;
    private string gender;

    protected Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    protected string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }


            name = value;
        }
    }

    protected int Age
    {
        get => age;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Invalid input!");
            }


            age = value;
        }
    }

    protected string Gender
    {
        get => gender;
        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }


            gender = value;
        }
    }

    public virtual string ProduceSound()
    {
        return string.Empty;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{this.GetType().Name}").AppendLine($"{this.Name} {this.Age} {this.Gender}")
            .Append(ProduceSound());

        return sb.ToString();
    }
}