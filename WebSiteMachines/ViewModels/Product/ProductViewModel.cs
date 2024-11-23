using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebSiteMachines.ViewModels.Product
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            products = new List<Models.Product>();
            AvailableCategories = new List<SelectListItem>();
        }


        public List<Models.Product>? products { get; set; }
        //public ProductFilter filter { get; set; }

        public string? Name { get; set; }
        public int CategoryId { get; set; }
        public List<SelectListItem> AvailableCategories { get; set; }
    }
}
