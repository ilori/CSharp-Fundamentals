namespace Forum.App.Controllers
{
    using System;
    using System.Linq;
    using Contracts;
    using Services;
    using UserInterface.Contracts;
    using UserInterface.Input;
    using UserInterface.ViewModels;
    using Views;

    public class AddReplyController : IController
    {
        private enum Command
        {
            Write,
            Post,
            Back
        }

        public AddReplyController()
        {
            this.ResetReply();
        }

        private const int TEXT_AREA_WIDTH = 37;
        private const int TEXT_AREA_HEIGHT = 6;
        private const int POST_MAX_LENGTH = 220;

        private static int centerTop = Position.ConsoleCenter().Top;
        private static int centerLeft = Position.ConsoleCenter().Left;

        public ReplyViewModel Reply { get; private set; }

        public PostViewModel Post { get; set; }

        public TextArea TextArea { get; set; }

        public bool Error { get; private set; }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command) index)
            {
                case Command.Write:
                    TextArea.Write();
                    this.Reply.Content = TextArea.Lines.ToArray();
                    return MenuState.AddReply;
                case Command.Post:
                    var replyAdded = PostService.TrySaveReply(this.Reply, Post.PostId);
                    if (!replyAdded)
                    {
                        this.Error = true;
                        return MenuState.Rerender;
                    }
                    return MenuState.ReplyAdded;
                case Command.Back:
                    return MenuState.Back;
            }

            throw new InvalidOperationException();
        }

        public IView GetView(string userName)
        {
            this.Reply.Author = userName;
            return new AddReplyView(this.Post, this.Reply, this.TextArea, this.Error);
        }

        public void ResetReply()
        {
            this.Error = false;
            this.Reply = new ReplyViewModel();
            var contentLenght = this.Post?.Content.Count ?? 0;
            this.TextArea = new TextArea(centerLeft - 18, centerTop + contentLenght - 6, TEXT_AREA_WIDTH,
                TEXT_AREA_HEIGHT,
                POST_MAX_LENGTH);
        }

        public void SetPostId(int postId)
        {
            this.Post = PostService.GetPostViewModel(postId);
            ResetReply();
        }
    }
}