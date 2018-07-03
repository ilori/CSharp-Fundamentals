namespace p06_Twitter.Data
{
    using System;
    using System.IO;
    using Contracts;

    public class TweetRepository : ITweetRepository
    {
        private const string ServerName = "ServerName.txt";

        private readonly string server = Path.Combine(Environment.CurrentDirectory, ServerName);


        public void SaveTweet(string message)
        {
            File.AppendAllText(server, $"{message}--");
        }
    }
}