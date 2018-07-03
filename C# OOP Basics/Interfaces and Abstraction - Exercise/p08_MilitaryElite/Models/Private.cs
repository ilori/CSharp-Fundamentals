public class Private : Soldier, IPrivate
{
    public Private(int id, string firstName, string lastName, double salary) : base(id, firstName, lastName)
    {
        Salary = salary;
    }

    public string Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public double Salary { get; }

    public override string ToString()
    {
        return $"{base.ToString()} Salary: {Salary:F2}";
    }
}