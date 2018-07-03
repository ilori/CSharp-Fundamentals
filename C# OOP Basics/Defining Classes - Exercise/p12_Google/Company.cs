public class Company
{
    public string Name { get; set; }

    public string Department { get; set; }

    public decimal Salary { get; set; }


    public override string ToString()
    {
        return $"{Name} {Department} {Salary:F2}";
    }
}