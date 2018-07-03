namespace p06_Twitter.Contracts
{
    public interface ITweetRepository
    {
        void SaveTweet(string message);
    }
}