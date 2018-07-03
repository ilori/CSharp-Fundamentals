using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public LeutenantGeneral(int id, string firstName, string lastName, double salary) : base(id, firstName, lastName,
        salary)
    {
    }

    private readonly ICollection<ISoldier> privates = new List<ISoldier>();

    public IReadOnlyCollection<ISoldier> Privates => (IReadOnlyCollection<ISoldier>) privates;

    public void AddPrivate(ISoldier soldier)
    {
        privates.Add(soldier);
    }


    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine(base.ToString()).AppendLine($"{nameof(Privates)}:");

        foreach (var @private in Privates)
        {
            sb.AppendLine($"  {@private}");
        }

        return sb.ToString().TrimEnd();
    }
}