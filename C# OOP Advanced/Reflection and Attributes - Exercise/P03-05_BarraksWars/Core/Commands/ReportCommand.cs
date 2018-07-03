public class ReportCommand : Command
{
    public ReportCommand(string[] data) : base(data)
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
        return this.Repository.Statistics;
    }
}