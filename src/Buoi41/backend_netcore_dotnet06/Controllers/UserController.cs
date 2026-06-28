using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_netcore_dotnet06.Helper;
using backend_netcore_dotnet06.Models.DBUser;
using Microsoft.AspNetCore.Mvc;
//using backend_netcore_dotnet06.Models;

namespace backend_netcore_dotnet06.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // tao list userDto de luu tru du lieu
        public static List<UserDTO> lstUsersDTO = new List<UserDTO>()
        {
            new UserDTO(){Id = 1, Name = "User 1", Email = "email1@example.com", Password = "password1"},
            new UserDTO(){Id = 2, Name = "User 2", Email = "email2@example.com", Password = "password2"},
            new UserDTO(){Id = 3, Name = "User 3", Email = "email3@example.com", Password = "password3"}
        };

        private readonly UserDBContext _context;
        private readonly JwtAuthService _jwt;
        public UserController(UserDBContext context, JwtAuthService jwt)
        {
            _context = context;
            _jwt = jwt;
        }



        [HttpGet("GetAllUser")]
        public List<UserDTO> GetUser()
        {
            return lstUsersDTO;
        }

        [HttpGet("GetUserById/{id}")]
        public UserDTO? GetUserById([FromRoute] int id)
        {
            return lstUsersDTO.FirstOrDefault(u => u.Id == id);
        }

        [HttpGet("SearchUserByName/{name}")]
        public List<UserDTO> SearchUserByName([FromRoute] string name)
        {
            return lstUsersDTO.Where(u => u.Name.Contains(name)).ToList();
        }

        [HttpPost("AddUser")]// FormBody la nguoi dung nhap lieu tu form
        public List<UserDTO> AddUser([FromBody] UserDTO user)
        {
            lstUsersDTO.Add(user);
            return lstUsersDTO;
        }


        [HttpDelete("DeleteUser/{id}")]
        public List<UserDTO> DeleteUser([FromRoute] int id)
        {
            var user = lstUsersDTO.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                lstUsersDTO.Remove(user);
            }
            return lstUsersDTO;
        }

        [HttpPut("UpdateUser/{id}")]
        public List<UserDTO> UpdateUser([FromRoute] int id, [FromBody] UserDTO user)
        {
            var existingUser = lstUsersDTO.FirstOrDefault(u => u.Id == id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;
            }
            return lstUsersDTO;
        }

        [HttpPatch("UpdatePassword/{id}")]
        public List<UserDTO> UpdatePassword([FromRoute] int id, [FromBody] string newPassword)
        {
            var existingUser = lstUsersDTO.FirstOrDefault(u => u.Id == id);
            if (existingUser != null)
            {
                existingUser.Password = newPassword;
            }
            return lstUsersDTO;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO model)
        {
            // Kiểm tra username và email có tồn tại hay không
           var user = _context.Users.SingleOrDefault(item => item.Username == model.Username || item.Email == model.Email);
           if(user!= null)
            {
                var res = new
                {
                    message = "Tai khoan hoac email da ton tai",
                    status = 408
                };
                return StatusCode(408, res);
            }

            // neu khong ton tai thi tao moi user
            User newUser = new User();
            newUser.Email = model.Email;
            newUser.Phone = model.Phone;
            newUser.Deleted = false;
            newUser.Username = model.Username;
            newUser.Fullname = model.FullName;
            newUser.HashPassword = HelperFunction.HashPassword(model.Password);

            // tao moi user role
            UserRole newUserRole = new UserRole();
            newUserRole.IdUser = newUser.Id;
            newUserRole.IdRole = CRole.User;
            newUserRole.Desc = "set vai tro thong qua view dang ky";

            // add userrole vao user
            newUser.UserRoles.Add(newUserRole);

            // add user vao dbcontext
            await _context.Users.AddAsync(newUser);

            // save changes vao db
            await _context.SaveChangesAsync();

            // try
            // {
            //     _context.Database.BeginTransaction();
            //
            //     _context.Database.CommitTransaction();
            // }
            // catch (Exception ex)
            // {
            //     _context.Database.RollBackTransaction();
            // }

            return Ok("Đăng ký thành công !");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO user)
        {
            // check login thanh cong thi tao token
            User? useCheckLogin = _context.Users.SingleOrDefault(item => item.Username == user.UserOrEmailOrPhone || item.Email == user.UserOrEmailOrPhone || item.Phone == user.UserOrEmailOrPhone);
            if (useCheckLogin == null)
            {
                return BadRequest("Sai tên đăng nhập");
            }
            // kiem tra password
            if (!HelperFunction.VerifyPassword(user.Password, useCheckLogin.HashPassword))
            {
                return BadRequest("Sai mật khẩu");
            }

            // neu dung thi tao token
            string token = _jwt.GenerateToken(user);
            return Ok(token );
        }


    }

}
