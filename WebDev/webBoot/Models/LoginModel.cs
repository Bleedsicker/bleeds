using System.ComponentModel.DataAnnotations;

namespace WebDev.Models;

public class LoginModel
{
    [Required(ErrorMessage = "Login is empty")]
    public string Username { get; set; }

    [StringLength(100, MinimumLength = 5, ErrorMessage = "Password too short")]
    public string Password { get; set; }

    public long Id { get; set; }
}
