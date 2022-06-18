using Microsoft.AspNetCore.Identity;

namespace IdentityUI.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string? FullName { get; set; }
    }
}
