﻿using Microsoft.AspNetCore.Identity;

namespace WebSiteMachines.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string? FirstName { get; set; }

    }
}