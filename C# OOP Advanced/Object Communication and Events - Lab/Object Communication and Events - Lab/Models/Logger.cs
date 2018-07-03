public abstract class Logger : IHandler
{
    private IHandler successor;

    public abstract void Handle(LogType type, string message);

    public void SetSuccessor(IHandler handler)
    {
        this.successor = handler;
    }

    protected void PassToSuccessor(LogType type, string message)
    {
        this.successor?.Handle(type, message);
    }
}