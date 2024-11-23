using Microsoft.AspNetCore.Mvc.Rendering;


namespace WebSiteMachines.FiltersModel
{
    public class ProductFilter
    {
        public ProductFilter()
        {
            AvailableCategories = new List<SelectListItem>();
        }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public List<SelectListItem> AvailableCategories { get; set; }
    }
}
