using PhoneDirectory.Business.DTO;
using PhoneDirectory.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectory.Business.Abstract
{
    public interface IUserBLL
    {
        List<UserDTO> GetAllUser();
        UserDTO GetUserByID(int userID);
        string AddUser(UserDTO entity);
        string UpdateUser(UserDTO entity,int userID);
        string DeleteUser(int userID);
        UserDetail UserDetail(UserDTO userDTO,List<ContactInfoDTO> contactInfoDTO);
        public List<LocationReport> DescendingLocationByUser(int userID);
    }
}
