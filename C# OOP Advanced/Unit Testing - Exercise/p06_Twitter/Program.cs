using System;

namespace p06_Twitter
{
    using Contracts;
    using Data;
    using IO;
    using Models;

    public class Program
    {
        public static void Main()
        {
            IWriter writer = new ConsoleWriter();
            ITweetRepository repo = new TweetRepository();
            IClient client = new MicrowaveOven(writer, repo);
            ITweet tweet = new Tweet(client);
        }
    }
}