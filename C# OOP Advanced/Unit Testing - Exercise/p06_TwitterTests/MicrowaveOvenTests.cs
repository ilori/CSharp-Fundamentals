namespace p06_TwitterTests
{
    using Moq;
    using NUnit.Framework;
    using p06_Twitter.Contracts;
    using p06_Twitter.Models;

    public class MicrowaveOvenTests
    {
        private const string Message = "LEVSKI";

        [Test]
        public void SendTweetMessageToServerShouldSaveTheMassage()
        {
            Mock<IWriter> writer = new Mock<IWriter>();

            Mock<ITweetRepository> repo = new Mock<ITweetRepository>();

            repo.Setup(x => x.SaveTweet(It.IsAny<string>()));

            IClient microwaveOven = new MicrowaveOven(writer.Object, repo.Object);

            microwaveOven.SendTweetToServer(Message);

            repo.Verify(tr => tr.SaveTweet(It.Is<string>(s => s == Message)), Times.Once);
        }

        [Test]
        public void WriteTweetMethodShouldCallWriterWithSameMessage()
        {
            Mock<IWriter> writer = new Mock<IWriter>();

            writer.Setup(w => w.WriteLine(It.IsAny<string>()));

            Mock<ITweetRepository> tweetRepo = new Mock<ITweetRepository>();

            IClient microwaveOven = new MicrowaveOven(writer.Object, tweetRepo.Object);

            microwaveOven.TweetMessage(Message);

            writer.Verify(w => w.WriteLine(It.Is<string>(s => s == Message)));
        }
    }
}