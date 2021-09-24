using PhoneDirectory.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectory.DataAccess.Abstract
{
    public interface IUserRepository
    {
        List<User> GetAllUser();
        User GetUserByID(int userID);
        int AddUser(User entity);
        int UpdateUser(User entity);
        int DeleteUser(int userID);
    }
}
