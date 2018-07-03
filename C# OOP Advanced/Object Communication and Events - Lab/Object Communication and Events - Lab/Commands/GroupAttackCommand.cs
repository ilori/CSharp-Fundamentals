public class GroupAttackCommand : ICommand
{
    private readonly IAttackGroup group;

    public GroupAttackCommand(IAttackGroup @group)
    {
        this.@group = @group;
    }

    public void Execute()
    {
        this.@group.GroupAttack();
    }
}