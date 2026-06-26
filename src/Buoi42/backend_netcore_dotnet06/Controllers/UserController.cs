using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


        public UserController()
        {
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


        
    }

}
