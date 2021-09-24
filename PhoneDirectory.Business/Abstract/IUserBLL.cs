using PhoneDirectory.WebApi.DTO;
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
    }
}
