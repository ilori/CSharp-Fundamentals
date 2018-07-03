namespace Forum.App.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Models;
    using static Controllers.SignUpController;

    public static class UserService
    {
        public static SignUpStatus TrySignUpUser(string username, string password)
        {
            var validUsername = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            var validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;

            if (!validPassword || !validUsername)
            {
                return SignUpStatus.DetailsError;
            }

            var forumData = new ForumData();

            var userAlreadyExists = forumData.Users.Any(x => x.Username == username);

            if (!userAlreadyExists)
            {
                var id = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
                var user = new User(id, username, password, new List<int>());
                forumData.Users.Add(user);
                forumData.SaveChanges();
                return SignUpStatus.Success;
            }

            return SignUpStatus.UsernameTakenError;
        }

        public static bool TryLoginUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            var forumData = new ForumData();

            var userExists = forumData.Users.Any(x => x.Username == username && x.Password == password);

            return userExists;
        }

        public static User GetUser(int id)
        {
            var forumData = new ForumData();

            var user = forumData.Users.SingleOrDefault(x => x.Id == id);

            return user;
        }

        public static User GetUser(string username, ForumData forumData)
        {
            var user = forumData.Users.SingleOrDefault(x => x.Username == username);
            return user;
        }
    }
}