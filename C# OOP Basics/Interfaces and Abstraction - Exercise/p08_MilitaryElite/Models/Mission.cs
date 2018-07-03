using System;

public class Mission : IMission
{
    public Mission(string codeName, string state)
    {
        CodeName = codeName;
        ParseMission(state);
    }

    private void ParseMission(string state)
    {
        var validState = Enum.TryParse<MissionState>(state, out var outMission);
        if (!validState)
        {
            throw new ArgumentException("Invalid state!");
        }

        this.State = (MissionState) outMission;
    }


    public string CodeName { get; }
    public MissionState State { get; set; }

    public void Complete()
    {
        if (State == MissionState.Finished)
        {
            throw new InvalidOperationException("Mission already finished!");
        }

        State = MissionState.Finished;
    }

    public override string ToString()
    {
        return $"Code Name: {CodeName} State: {State.ToString()}";
    }
}