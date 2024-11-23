using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebSiteMachines.ViewModels.Product
{
    public class ProductUpsertViewModel
    {
        public ProductUpsertViewModel()
        {
            Categories = new List<SelectListItem>();
        }
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile? Image { get; set; }
        public string? CurrentImageUrl { get; set; }
        public int CategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}
