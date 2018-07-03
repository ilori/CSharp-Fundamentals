namespace p06_Twitter.Models
{
    using Contracts;

    public class Tweet : ITweet
    {
        private readonly IClient client;

        public Tweet(IClient client)
        {
            this.client = client;
        }

        public void ReceiveTweet(string message)
        {
            this.client.TweetMessage(message);
            this.client.SendTweetToServer(message);
        }
    }
}