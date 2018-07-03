namespace p06_TwitterTests
{
    using Moq;
    using NUnit.Framework;
    using p06_Twitter.Contracts;
    using p06_Twitter.Models;

    public class TweetTests
    {
        private const string Message = "LEVSKI";

        [Test]
        public void ReceiveMessageShouldInvokeItsClientToWriteTheMessage()
        {
            Mock<IClient> client = new Mock<IClient>();

            client.Setup(c => c.TweetMessage(It.IsAny<string>()));

            ITweet tweet = new Tweet(client.Object);

            tweet.ReceiveTweet(Message);

            client.Verify(c => c.TweetMessage(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ReceiveMessageShouldInvokeItsClientToSendTheMessageToTheServer()
        {
            Mock<IClient> client = new Mock<IClient>();

            client.Setup(c => c.SendTweetToServer(It.IsAny<string>()));

            ITweet tweet = new Tweet(client.Object);

            tweet.ReceiveTweet(Message);

            client.Verify(c => c.SendTweetToServer(It.IsAny<string>()), Times.Once);
        }
    }
}