using Microsoft.AspNetCore.Identity;

namespace CarBook.IdentityServer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
