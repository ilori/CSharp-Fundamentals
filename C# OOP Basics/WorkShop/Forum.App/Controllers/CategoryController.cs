namespace Forum.App.Controllers
{
    using System.Linq;
    using Contracts;
    using Services;
    using UserInterface.Contracts;
    using Views;

    public class CategoryController : IController, IPaginationController
    {
        private enum Command
        {
            Back = 0,
            ViewPost = 1,
            PreviousPage = 11,
            NextPage = 12
        }

        public CategoryController()
        {
            this.CurrentPage = 0;
            this.SetCategory(0);
        }

        public const int PAGE_OFFSET = 10;
        private const int COMMAND_COUNT = PAGE_OFFSET + 3;

        public int CurrentPage { get; set; }

        public string[] PostTitles { get; set; }

        private int LastPage => PostTitles.Length / (PAGE_OFFSET + 1);

        private bool IsFirstPage => this.CurrentPage == 0;
        private bool IsLastPage => this.CurrentPage == this.LastPage;

        public int CategoryId { get; private set; }

        public MenuState ExecuteCommand(int index)
        {
            if (index > 1 && index < 11)
            {
                index = 1;
            }

            switch ((Command) index)
            {
                case Command.Back:
                    return MenuState.Back;
                case Command.ViewPost:
                    return MenuState.ViewPost;
                case Command.PreviousPage:
                    ChangePage(false);
                    return MenuState.Rerender;
                case Command.NextPage:
                    ChangePage();
                    return MenuState.Rerender;
            }

            throw new InvalidCommandException();
        }

        public IView GetView(string userName)
        {
            this.GetPosts();
            var categoryName = PostService.GetCategory(this.CategoryId).Name;

            return new CategoryView(categoryName, PostTitles, IsFirstPage, IsLastPage);
        }

        public void SetCategory(int categoryId)
        {
            this.CategoryId = categoryId;
        }

        private void ChangePage(bool forward = true)
        {
            this.CurrentPage += forward ? 1 : -1;
        }

        private void GetPosts()
        {
            var allCategoryPosts = PostService.GetPostsByCategory(this.CategoryId);

            this.PostTitles = allCategoryPosts.Skip(this.CurrentPage * PAGE_OFFSET).Take(PAGE_OFFSET)
                .Select(x => x.Title).ToArray();
        }
    }
}