namespace Forum.App.UserInterface.Contracts
{
    using App;

    public interface ILabel : IPositionable
    {
        string Text { get; }

        bool IsHidden { get; }
    }
}