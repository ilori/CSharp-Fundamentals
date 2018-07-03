namespace Forum.App.Controllers
{
    using System;
    using Contracts;
    using Services;
    using UserInterface;
    using UserInterface.Contracts;
    using Views;


    public class PostDetailsController : IController, IUserRestrictedController
    {
        private enum Command
        {
            Back,
            AddReply
        }

        public bool LoggedInUser { get; set; }

        public int PostId { get; private set; }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command) index)
            {
                case Command.Back:
                    ForumViewEngine.ResetBuffer();
                    return MenuState.Back;
                case Command.AddReply:
                    return MenuState.AddReplyToPost;
            }
            throw new InvalidOperationException();
        }

        public IView GetView(string userName)
        {
            var postViewModel = PostService.GetPostViewModel(this.PostId);

            return new PostDetailsView(postViewModel, this.LoggedInUser);
        }

        public void UserLogIn()
        {
            this.LoggedInUser = true;
        }

        public void UserLogOut()
        {
            this.LoggedInUser = false;
        }

        public void SetPostId(int postId)
        {
            this.PostId = postId;
        }
    }
}