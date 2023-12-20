using System.ComponentModel.DataAnnotations;

namespace CarBook.Dto.Dtos.Auth;

public class RegisterDto
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string FullName{ get; set; }
    [Required]
    public string City { get; set; }
}