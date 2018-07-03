namespace Forum.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Models;

    public class DataMapper
    {
        static DataMapper()
        {
            Directory.CreateDirectory(DATA_PATH);
            config = LoadConfig(DATA_PATH + CONFIG_PATH);
        }

        private const string DATA_PATH = "../data/";

        private const string CONFIG_PATH = "config.ini";

        private const string DEFAULT_CONFIG =
            "users=users.csv\r\ncategories=categories.csv\r\nposts=posts.csv\r\nreplies=replies.csv";

        private static readonly Dictionary<string, string> config;

        private static void EnsureConfigFile(string configPath)
        {
            if (!File.Exists(configPath))
            {
                File.WriteAllText(configPath, DEFAULT_CONFIG);
            }
        }

        private static void EnsureFile(string path)
        {
            if (!File.Exists(DATA_PATH + path))
            {
                File.Create(DATA_PATH + path).Close();
            }
        }

        private static string[] ReadLines(string path)
        {
            EnsureFile(DATA_PATH + path);
            var lines = File.ReadAllLines(DATA_PATH + path);
            return lines;
        }

        private static void WriteLines(string path, string[] lines)
        {
            File.WriteAllLines(DATA_PATH + path, lines);
        }

        private static Dictionary<string, string> LoadConfig(string configPath)
        {
            EnsureConfigFile(configPath);

            var contents = ReadLines(configPath);

            var config = contents.Select(x => x.Split('=')).ToDictionary(t => t[0], t => t[1]);

            return config;
        }

        public static List<Category> LoadCategories()
        {
            var lines = ReadLines(config["categories"]);

            var categories = new List<Category>();

            foreach (var line in lines)
            {
                var tokens = line.Split(";");
                var id = int.Parse(tokens[0]);
                var name = tokens[1];
                var postIds = tokens[2].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                categories.Add(new Category(id, name, postIds));
            }

            return categories;
        }

        public static void SaveCategories(List<Category> categories)
        {
            const string categoryFormat = "{0};{1};{2}";
            var lines = new List<string>();

            foreach (var category in categories)
            {
                var line = string.Format(categoryFormat, category.Id, category.Name,
                    string.Join(",", category.PostIds));

                lines.Add(line);
            }

            WriteLines(config["categories"], lines.ToArray());
        }

        public static List<User> LoadUsers()
        {
            var lines = ReadLines(config["users"]);

            var users = new List<User>();

            foreach (var line in lines)
            {
                var tokens = line.Split(";");
                var id = int.Parse(tokens[0]);
                var userName = tokens[1];
                var password = tokens[2];
                var postIds = tokens[3].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                users.Add(new User(id, userName, password, postIds));
            }

            return users;
        }

        public static void SaveUsers(List<User> users)
        {
            const string userFormat = "{0};{1};{2};{3}";
            var lines = new List<string>();

            foreach (var user in users)
            {
                var line = string.Format(userFormat, user.Id, user.Username, user.Password,
                    string.Join(",", user.PostIds));

                lines.Add(line);
            }

            WriteLines(config["users"], lines.ToArray());
        }

        public static List<Post> LoadPosts()
        {
            var lines = ReadLines(config["posts"]);

            var posts = new List<Post>();

            foreach (var line in lines)
            {
                var tokens = line.Split(";");
                var id = int.Parse(tokens[0]);
                var title = tokens[1];
                var content = tokens[2];
                var categoryId = int.Parse(tokens[3]);
                var authorId = int.Parse(tokens[4]);
                var replyIds = tokens[5].Split(",",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                posts.Add(new Post(id, title, content, categoryId, authorId, replyIds));
            }

            return posts;
        }

        public static void SavePosts(List<Post> posts)
        {
            const string postFormat = "{0};{1};{2};{3};{4};{5}";
            var lines = new List<string>();

            foreach (var post in posts)
            {
                var line = string.Format(postFormat, post.Id, post.Title, post.Content, post.CategoryId, post.AuthorId,
                    string.Join(",", post.ReplyIds));

                lines.Add(line);
            }

            WriteLines(config["posts"], lines.ToArray());
        }

        public static List<Reply> LoadReplies()
        {
            var lines = ReadLines(config["replies"]);

            var replies = new List<Reply>();

            foreach (var line in lines)
            {
                var tokens = line.Split(";");
                var id = int.Parse(tokens[0]);
                var content = tokens[1];
                var authorId = int.Parse(tokens[2]);
                var postId = int.Parse(tokens[3]);
                replies.Add(new Reply(id, content, authorId, postId));
            }

            return replies;
        }

        public static void SaveReplies(List<Reply> replies)
        {
            const string replyFormat = "{0};{1};{2};{3}";
            var lines = new List<string>();

            foreach (var reply in replies)
            {
                var line = string.Format(replyFormat, reply.Id, reply.Content, reply.AuthorId, reply.PostId);

                lines.Add(line);
            }

            WriteLines(config["replies"], lines.ToArray());
        }
    }
}