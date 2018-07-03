public class AddCommand : Command
{
    [Inject] private IRepository repository;


    [Inject] private IUnitFactory unitFactory;


    public AddCommand(string[] data) : base(data)
    {
    }


    public IRepository Repository
    {
        get => repository;
        set => repository = value;
    }

    public IUnitFactory UnitFactory
    {
        get => unitFactory;
        set => unitFactory = value;
    }

    public override string Execute()
    {
        string type = this.Data[1];

        IUnit unit = UnitFactory.CreateUnit(type);

        this.Repository.AddUnit(unit);

        string result = $"{unit.GetType().Name} added!";

        return result;
    }
}