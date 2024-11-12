namespace WebSiteMachines.ViewModels.Product
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            productSearchViewModel = new ProductSearchViewModel();
            products = new List<Models.Product>();
        }


        public List<Models.Product>? products { get; set; }
        public ProductSearchViewModel? productSearchViewModel { get; set; }
    }
}
