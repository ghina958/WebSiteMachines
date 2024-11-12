using Microsoft.AspNetCore.Identity;

namespace WebSiteMachines.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }

    }
}
