namespace Forum.App.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Models;
    using UserInterface.ViewModels;

    public static class PostService
    {
        public static Category GetCategory(int id)
        {
            var forumData = new ForumData();

            var category = forumData.Categories.SingleOrDefault(x => x.Id == id);

            return category;
        }

        public static IList<ReplyViewModel> GetReplies(int postId)
        {
            var forumData = new ForumData();
            var post = forumData.Posts.SingleOrDefault(x => x.Id == postId);

            var replies = new List<ReplyViewModel>();

            foreach (var replyId in post.ReplyIds)
            {
                var reply = forumData.Replies.FirstOrDefault(x => x.Id == replyId);

                replies.Add(new ReplyViewModel(reply));
            }

            return replies;
        }

        public static string[] GetAllCategoryNames()
        {
            var forumData = new ForumData();

            var allCategories = forumData.Categories.Select(x => x.Name).ToArray();

            return allCategories;
        }

        public static IEnumerable<Post> GetPostsByCategory(int categoryId)
        {
            var forumData = new ForumData();

            var postIds = forumData.Categories.FirstOrDefault(x => x.Id == categoryId).PostIds;

            var posts = forumData.Posts.Where(x => postIds.Contains(x.Id));

            return posts;
        }

        public static PostViewModel GetPostViewModel(int postId)
        {
            var forumData = new ForumData();
            var post = forumData.Posts.SingleOrDefault(x => x.Id == postId);

            var postViewModel = new PostViewModel(post);

            return postViewModel;
        }

        private static Category EnsureCategory(PostViewModel postViewModel, ForumData forumData)
        {
            var categoryName = postViewModel.Category;
            var category = forumData.Categories.SingleOrDefault(x => x.Name == categoryName);

            if (category == null)
            {
                var categories = forumData.Categories;
                var categoryId = categories.Any() ? categories.Last().Id + 1 : 1;

                category = new Category(categoryId, categoryName, new List<int>());
                forumData.Categories.Add(category);
            }

            return category;
        }

        public static bool TrySavePost(PostViewModel model)
        {
            var isTitleValid = !string.IsNullOrWhiteSpace(model.Title);
            var isContentValid = model.Content.Any();
            var isCategoryValid = !string.IsNullOrWhiteSpace(model.Category);

            if (!isTitleValid || !isContentValid || !isCategoryValid)
            {
                return false;
            }

            var forumData = new ForumData();

            var category = EnsureCategory(model, forumData);

            var postId = forumData.Posts.LastOrDefault()?.Id + 1 ?? 1;
            var author = UserService.GetUser(model.Author, forumData);
            var content = string.Join("", model.Content);
            var post = new Post(postId, model.Title, content, category.Id, author.Id, new List<int>());
            forumData.Posts.Add(post);
            category.PostIds.Add(postId);
            author.PostIds.Add(postId);
            forumData.SaveChanges();
            model.PostId = postId;
            return true;
        }

        public static bool TrySaveReply(ReplyViewModel model, int postId)
        {
            if (!model.Content.Any())
            {
                return false;
            }

            var forumData = new ForumData();
            var author = UserService.GetUser(model.Author, forumData);
            var post = forumData.Posts.Single(x => x.Id == postId);
            var replyId = forumData.Replies.LastOrDefault()?.Id + 1 ?? 1;
            var content = string.Join("", model.Content);
            var reply = new Reply(replyId, content, author.Id, postId);
            forumData.Replies.Add(reply);
            post.ReplyIds.Add(replyId);
            forumData.SaveChanges();
            return true;
        }
    }
}