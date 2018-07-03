namespace p06_Twitter.Models
{
    using Contracts;

    public class MicrowaveOven : IClient
    {
        private readonly IWriter writer;
        private readonly ITweetRepository repo;

        public MicrowaveOven(IWriter writer, ITweetRepository repo)
        {
            this.writer = writer;
            this.repo = repo;
        }

        public void TweetMessage(string message)
        {
            this.writer.WriteLine(message);
        }

        public void SendTweetToServer(string message)
        {
            this.repo.SaveTweet(message);
        }
    }
}