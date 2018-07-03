public class StartUp
{
    public static void Main()
    {
        var repository = new WeaponRepository();
        var interpreter = new CommandInterpreter();
        var weaponFactory = new WeaponFactory();
        var gemFactory = new GemFactory();

        IRunnable engine = new Engine(gemFactory, weaponFactory, interpreter, repository);

        engine.Run();

    }
}