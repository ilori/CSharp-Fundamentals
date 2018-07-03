public abstract class Command : IExecutable
{
    protected Command(string[] data)
    {
        this.Data = data;
    }

    protected string[] Data { get; }

    public abstract void Execute();
}