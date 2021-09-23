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
        void AddUser(User entity);
        void UpdateUser(User entity);
        void DeleteUser(int userID);
    }
}
