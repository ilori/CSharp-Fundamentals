namespace Forum.App.UserInterface.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Services;

    public class ReplyViewModel
    {
        private const int LINE_LENGHT = 37;

        public ReplyViewModel()
        {
            this.Content = new List<string>();
        }

        public ReplyViewModel(Reply reply)
        {
            this.Author = UserService.GetUser(reply.AuthorId).Username;
            this.Content = GetLines(reply.Content);
        }


        public string Author { get; set; }

        public IList<string> Content { get; set; }

        private IList<string> GetLines(string content)
        {
            var contentChars = content.ToCharArray();
            var lines = new List<string>();
            for (int i = 0; i < content.Length; i += LINE_LENGHT)
            {
                var row = contentChars.Skip(i).Take(LINE_LENGHT).ToArray();
                var rowString = string.Join("", row);
                lines.Add(rowString);
            }

            return lines;
        }
    }
}