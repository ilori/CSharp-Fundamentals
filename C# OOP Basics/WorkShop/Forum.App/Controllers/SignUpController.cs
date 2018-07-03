namespace Forum.App.Controllers
{
    using System;
    using App;
    using Contracts;
    using Services;
    using UserInterface;
    using UserInterface.Contracts;

    public class SignUpController : IController, IReadUserInfoController
    {
        public SignUpController()
        {
            this.ResetSignUp();
        }

        private enum Command
        {
            ReadUsername,
            ReadPassword,
            SignUp,
            Back
        }

        public enum SignUpStatus
        {
            Success,
            DetailsError,
            UsernameTakenError
        }

        private const string DETAILS_ERROR = "Invalid Username or Password!";
        private const string USERNAME_TAKEN_ERROR = "Username already in use!";

        public string Username { get; set; }

        public string Password { get; set; }

        private string ErrorMessage { get; set; }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command) index)
            {
                case Command.ReadUsername:
                    ReadUsername();
                    return MenuState.Signup;
                case Command.ReadPassword:
                    ReadPassword();
                    return MenuState.Signup;
                case Command.SignUp:
                    var signUp = UserService.TrySignUpUser(this.Username, this.Password);
                    switch (signUp)
                    {
                        case SignUpStatus.Success:
                            return MenuState.SuccessfulLogIn;
                        case SignUpStatus.DetailsError:
                            this.ErrorMessage = DETAILS_ERROR;
                            return MenuState.Error;
                        case SignUpStatus.UsernameTakenError:
                            this.ErrorMessage = USERNAME_TAKEN_ERROR;
                            return MenuState.Error;
                    }
                    break;
                case Command.Back:
                    ResetSignUp();
                    return MenuState.Back;
            }

            throw new InvalidOperationException();
        }

        public IView GetView(string userName)
        {
            return new SignUpView(this.ErrorMessage);
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

        public void ResetSignUp()
        {
            this.Username = string.Empty;
            this.ErrorMessage = string.Empty;
            this.Password = string.Empty;
        }
    }
}