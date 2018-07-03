namespace Forum.App.Controllers
{
    using System;
    using Contracts;
    using Services;
    using UserInterface;
    using UserInterface.Contracts;
    using Views;

    public class LogInController : IController, IReadUserInfoController
    {
        private enum Command
        {
            ReadUsername,
            ReadPassword,
            LogIn,
            Back
        }

        public LogInController()
        {
            this.ResetLogin();
        }

        public string Username { get; private set; }

        private string Password { get; set; }

        private bool Error { get; set; }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command) index)
            {
                case Command.ReadUsername:
                    this.ReadUsername();
                    return MenuState.Login;
                case Command.ReadPassword:
                    this.ReadPassword();
                    return MenuState.Login;
                case Command.LogIn:
                    var userLoggedIn = UserService.TryLoginUser(Username, Password);
                    if (userLoggedIn)
                    {
                        return MenuState.SuccessfulLogIn;
                    }
                    this.Error = true;
                    return MenuState.Error;
                case Command.Back:
                    ResetLogin();
                    return MenuState.Back;
            }

            throw new InvalidOperationException();
        }

        public IView GetView(string userName)
        {
            return new LogInView(this.Error, this.Username, this.Password.Length);
        }

        public void ReadPassword()
        {
            this.Password = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public void ReadUsername()
        {
            this.Username = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        private void ResetLogin()
        {
            this.Error = false;
            this.Username = string.Empty;
            this.Password = string.Empty;
        }
    }
}