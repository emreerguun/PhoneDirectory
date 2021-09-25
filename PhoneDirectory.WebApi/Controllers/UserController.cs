using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneDirectory.Business.Abstract;
using PhoneDirectory.Business.DTO;
using PhoneDirectory.Business.Models;
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
        private IContactInfoBLL contactInfoBLL;
        public UserController(IUserBLL _userBLL,IContactInfoBLL _contactInfoBLL)
        {
            userBLL = _userBLL;
            contactInfoBLL = _contactInfoBLL;
        }

        [HttpGet()]
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

        [HttpGet("getuserdetail/{userID}")]
        public UserDetail GetUserDetailByID(int userID)
        {
            UserDTO userDTO = userBLL.GetUserByID(userID);
            List<ContactInfoDTO> contactInfoDTO = contactInfoBLL.GetContactInfosByUserID(userID);
            UserDetail userDetail = userBLL.UserDetail(userDTO,contactInfoDTO);
            return userDetail;
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

        [HttpGet("descending-location/{userID}")]
        public List<LocationReport> DescendingLocationByUser(int userID) 
        {
            return userBLL.DescendingLocationByUser(userID);
        }
    }
}
