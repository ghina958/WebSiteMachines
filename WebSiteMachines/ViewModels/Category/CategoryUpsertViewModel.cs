namespace WebSiteMachines.ViewModels.Category
{
    public class CategoryUpsertViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile? Image { get; set; }
        public string? CurrentImageUrl { get; set; }
    }
}
