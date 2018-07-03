using System;

public class RetireCommand : Command
{
    public RetireCommand(string[] data) : base(data)
    {
    }

    [Inject] private IRepository repository;

    public IRepository Repository
    {
        get => repository;
        set => repository = value;
    }

    public override string Execute()
    {
        string type = this.Data[1];

        try
        {
            this.Repository.RemoveUnit(type);

            return $"{type} retired!";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }
}