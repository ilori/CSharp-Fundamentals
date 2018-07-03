using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public Engineer(int id, string firstName, string lastName, double salary, string corps) : base(id, firstName,
        lastName, salary, corps)
    {
    }

    private readonly ICollection<IRepair> repairs = new List<IRepair>();

    public IReadOnlyCollection<IRepair> Repairs => (IReadOnlyCollection<IRepair>) repairs;

    public void AddRepair(IRepair repair)
    {
        repairs.Add(repair);
    }


    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine(base.ToString()).AppendLine($"{nameof(Corps)}: {Corps.ToString()}")
            .AppendLine($"{nameof(Repairs)}:");

        foreach (var repair in Repairs)
        {
            sb.AppendLine($"  {repair}");
        }

        return sb.ToString().TrimEnd();
    }
}