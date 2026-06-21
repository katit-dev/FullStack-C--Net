// xay dung cac restful api cho userDTO(id, name, email, password)
// get: getall, getbyid, searchbyname
// post: adduser
// delete: deleteuser
// put: updateuser
// pathc :updatepassword

using System.ComponentModel.DataAnnotations;

public class UserDTO
{
[Required(ErrorMessage = "Id là bắt buộc")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name không được để trống")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Tên phải từ 3 đến 50 ký tự")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email không được để trống")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password không được để trống")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password phải ít nhất 6 ký tự")]
    public string Password { get; set; }
}