public class GroupTargetCommand : ICommand
{
    private readonly ITarget target;
    private readonly IAttackGroup group;


    public GroupTargetCommand(ITarget target, IAttackGroup group)
    {
        this.target = target;
        this.@group = group;
    }

    public void Execute()
    {
        this.@group.GroupTarget(this.target);
    }
}