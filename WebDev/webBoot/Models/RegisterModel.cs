using System.ComponentModel.DataAnnotations;

namespace WebDev.Models;

public class RegisterModel
{
    [Required(ErrorMessage = "Try again")]
    public string Username { get; set; }

    //[Phone]
    //RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "Password is short")]
    public string Password { get; set; }

    public string PasswordConfirmation { get; set; }
}
