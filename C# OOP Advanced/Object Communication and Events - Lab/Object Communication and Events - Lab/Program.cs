public class Program
{
    public static void Main()
    {
        Logger combatLogger = new CombatLogger();
        Logger eventLogger = new EventLogger();

        combatLogger.SetSuccessor(eventLogger);

        IAttackGroup group = new Group();

        group.AddMember(new Warrior("Pesho", 10, combatLogger));
        group.AddMember(new Warrior("Shosho", 20, combatLogger));

        ITarget dragon = new Dragon("Bla", 500, 150, combatLogger);

        IExecutor executor = new CommandExecutor();

        ICommand groupTargetCommand = new GroupTargetCommand(dragon,group);
        ICommand attackTargetCommand = new GroupAttackCommand(group);

        executor.ExecuteCommand(groupTargetCommand);
        executor.ExecuteCommand(attackTargetCommand);
    }
}