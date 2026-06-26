using System.ComponentModel.DataAnnotations;

public class UserRegisterDTO
{
    [Required(ErrorMessage = "Username không được để trống")]
    [StringLength(32, MinimumLength = 6, ErrorMessage = "Username phải từ 6 đến 32 ký tự")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password không được để trống")]
    [StringLength(32, MinimumLength = 6, ErrorMessage = "Password phải từ 6 đến 32 ký tự")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email không được để trống")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Số điện thoại không được để trống")]
    [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
    public string Phone { get; set; } = string.Empty;
}