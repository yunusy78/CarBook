using System.ComponentModel.DataAnnotations;

namespace CarBook.IdentityServer.Models
{
    public class SignUpDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email{ get; set; }
        [Required]
        public string Name { get; set; }
    }
}