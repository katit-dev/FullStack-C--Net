
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
        public static List<UserDTO> lstUserDTO = new List<UserDTO>()
        {
             new UserDTO(){Id = 1, Name = "User 1", Email = "email1@example.com", Password = "password1"},
            new UserDTO(){Id = 2, Name = "User 2", Email = "email2@example.com", Password = "password2"},
            new UserDTO(){Id = 3, Name = "User 3", Email = "email3@example.com", Password = "password3"}
        };
        public UserController()
        {
        }


        // getAll
        [HttpGet("GetAllUser")]
        public List<UserDTO> GetAllUser()
        {
            return lstUserDTO;
        }

        // getUserById
        [HttpGet("GetUserById/{id}")]
        public UserDTO? GetUserById([FromRoute] int id)
        {
            var user = lstUserDTO.FirstOrDefault(p => p.Id == id);
            if(user != null)
            {
                return user;
            }
            return null;
            
        }

        // search
        [HttpGet("SearchUserByName/{name}")]
        public List<UserDTO> SearchUserByName([FromRoute] string name)
        {
            var users = lstUserDTO.Where(p => p.Name.Contains(name));
            return users.ToList();
            
        }

        // add
        [HttpPost("AddUser")]
        public List<UserDTO> AddUser([FromBody] UserDTO newUser)
        {
            var user = lstUserDTO.FirstOrDefault(p => p.Id == newUser.Id);
            // neu tim thay ==> bi trung ==> nem loi
            if(user != null)
            {
                throw new Exception("Id đã tồn tại");
            }
            lstUserDTO.Add(newUser);
            return lstUserDTO;
        }

        // delete
        [HttpDelete("DeleteUser/{id}")]
        public List<UserDTO> DeleteUser([FromRoute]int id)
        {
            var user = lstUserDTO.FirstOrDefault(p => p.Id == id);
            if(user != null)
            {
                lstUserDTO.Remove(user);
            }
            return lstUserDTO;
        }

        // update 
        [HttpPut("UpdateUser/{id}")]
        public List<UserDTO> UpdateUser([FromRoute] int id, [FromBody] UserDTO newuser)
        {
            var user = lstUserDTO.FirstOrDefault(p => p.Id == id);
            if(user != null)
            {
                user.Name = newuser.Name;
                user.Email = newuser.Email;
                user.Password = newuser.Password;
            }
            return lstUserDTO;
        }

        // update password only
        [HttpPatch("UpdateUserPassword/{id}")]
        public List<UserDTO> UpdateUserPassword([FromRoute] int id, [FromBody] string newPassword)
        {
            var user = lstUserDTO.FirstOrDefault(p => p.Id == id);
            if(user != null)
            {
                user.Password = newPassword;
            }
            return lstUserDTO;
        }

        
    }
}