
namespace Web.ViewModels.OurTeam
{
    public class OurTeamUpsertViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public string position { get; set; }

        public string Image { get; set; }

        public IFormFile FileImage { get; set; }
    }
}
