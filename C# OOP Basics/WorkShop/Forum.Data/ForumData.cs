namespace Forum.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class ForumData
    {
        public ForumData()
        {
            this.Users = DataMapper.LoadUsers();
            this.Categories = DataMapper.LoadCategories();
            this.Posts = DataMapper.LoadPosts();
            this.Replies = DataMapper.LoadReplies();
        }


        public ICollection<User> Users { get; set; }

        public ICollection<Category> Categories { get; set; }

        public ICollection<Reply> Replies { get; set; }

        public ICollection<Post> Posts { get; set; }


        public void SaveChanges()
        {
            DataMapper.SaveUsers(this.Users.ToList());
            DataMapper.SaveCategories(this.Categories.ToList());
            DataMapper.SavePosts(this.Posts.ToList());
            DataMapper.SaveReplies(this.Replies.ToList());
        }
    }
}