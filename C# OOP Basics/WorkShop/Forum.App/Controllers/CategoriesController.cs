namespace Forum.App.Controllers
{
    using System.Linq;
    using Contracts;
    using Services;
    using UserInterface.Contracts;
    using Views;

    public class CategoriesController : IController, IPaginationController
    {
        private enum Command
        {
            Back = 0,
            ViewCategory = 1,
            PreviousPage = 11,
            NextPage = 12
        }

        public const int PAGE_OFFSET = 10;
        private const int COMMAND_COUNT = PAGE_OFFSET + 3;

        public CategoriesController()
        {
            this.CurrentPage = 0;
            this.LoadCategories();
        }


        public int CurrentPage { get; set; }

        public string[] AllCategoriesName { get; set; }

        public string[] CurrentPageCategories { get; set; }

        private int LastPage => AllCategoriesName.Length / (PAGE_OFFSET + 1);

        private bool IsFirstPage => this.CurrentPage == 0;
        private bool IsLastPage => this.CurrentPage == this.LastPage;

        private void ChangePage(bool forward = true)
        {
            this.CurrentPage += forward ? 1 : -1;
        }

        private void LoadCategories()
        {
            this.AllCategoriesName = PostService.GetAllCategoryNames();
            this.CurrentPageCategories =
                this.AllCategoriesName.Skip(this.CurrentPage * PAGE_OFFSET).Take(PAGE_OFFSET).ToArray();
        }

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
                case Command.ViewCategory:
                    return MenuState.OpenCategory;
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
            this.LoadCategories();
            return new CategoriesView(this.CurrentPageCategories, IsFirstPage, IsLastPage);
        }
    }
}