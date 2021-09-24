using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneDirectory.Business.Abstract;
using PhoneDirectory.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectory.WebApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private IUserBLL userBLL;
        public UserController(IUserBLL _userBLL)
        {
            userBLL = _userBLL;
        }

        [HttpGet("userlist")]
        public List<UserDTO> UserList()
        {
            return userBLL.GetAllUser();
        }

        [HttpGet("getuserbyid/{userID}")]
        public UserDTO GetUserByID(int userID)
        {
            UserDTO user = userBLL.GetUserByID(userID);
            return user;
        }

        [HttpPost("adduser")]
        public string AddUser(UserDTO userDto)
        {
            return userBLL.AddUser(userDto);
        }

        [HttpPut("updateuser/{userID}")]
        public string UpdateUser(int userID,UserDTO userDto) 
        {
            return userBLL.UpdateUser(userDto,userID);
        }

        [HttpDelete("deleteuser/{userID}")]
        public string DeleteUser(int userID)
        {
            return userBLL.DeleteUser(userID);
        }
    }
}
