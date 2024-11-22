
namespace WebSiteMachines.ViewModels.Category
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            CategorySearchViewModel = new CategorySearchViewModel();
        }
        public List<Models.Category>? Categories { get; set; }
        public CategorySearchViewModel? CategorySearchViewModel { get; set; }
    }
}
