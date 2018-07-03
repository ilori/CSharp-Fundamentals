using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    public Commando(int id, string firstName, string lastName, double salary, string corps) : base(id, firstName,
        lastName, salary, corps)
    {
    }

    private readonly ICollection<IMission> missions = new List<IMission>();
    public IReadOnlyCollection<IMission> Missions => (IReadOnlyCollection<IMission>) missions;

    public void AddMission(IMission mission)
    {
        missions.Add(mission);
    }

    public void CompleteMission(string code)
    {
        var mission = Missions.SingleOrDefault(x => x.CodeName == code);

        if (mission == null)
        {
            throw new ArgumentException("Invalid mission!");
        }

        mission.Complete();
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine(base.ToString()).AppendLine($"{nameof(Corps)}: {Corps.ToString()}")
            .AppendLine($"{nameof(Missions)}:");

        foreach (var mission in Missions)
        {
            sb.AppendLine($"  {mission}");
        }

        return sb.ToString().TrimEnd();
    }
}