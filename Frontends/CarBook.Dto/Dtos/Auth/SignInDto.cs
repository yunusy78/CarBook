using System.ComponentModel.DataAnnotations;

namespace CarBook.Dto.Dtos.Auth;

public class SignInDto
{
    [Required]
    [Display(Name = "Email")]
    public string Email { get; set; }
    [Display(Name = "Password")]
    public string Password { get; set; }
    [Display(Name = "Remember Me")]
    public bool RememberMe { get; set; }
}