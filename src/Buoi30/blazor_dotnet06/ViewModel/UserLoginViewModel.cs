using System.ComponentModel.DataAnnotations;

public class UserLoginViewModel
{
    [Required(ErrorMessage = "Vui lòng nhập username")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập password")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng chọn role")]
    public string Role { get; set; } = string.Empty;
}