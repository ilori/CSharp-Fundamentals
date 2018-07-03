namespace p06_Twitter.Contracts
{
    public interface IClient
    {
        void TweetMessage(string message);

        void SendTweetToServer(string message);
    }
}