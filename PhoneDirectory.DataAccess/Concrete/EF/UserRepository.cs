using PhoneDirectory.DataAccess.Abstract;
using PhoneDirectory.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneDirectory.DataAccess.Concrete.EF
{
    public class UserRepository : IUserRepository
    {
        private PhoneDirectoryContext context;
        public UserRepository(PhoneDirectoryContext _context)
        {
            context = _context;
        }

        public List<User> GetAllUser()
        {
            return context.Users.ToList();
        }

        public User GetUserByID(int userID)
        {
            return context.Users.FirstOrDefault(x => x.UserID == userID);
        }

        public void AddUser(User entity)
        {
            context.Users.Add(entity);
            context.SaveChanges();
        }

        public void DeleteUser(int userID)
        {
            User user = GetUserByID(userID);
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public void UpdateUser(User entity)
        {
            User user = GetUserByID(entity.UserID);
            if (user!=null)
            {
                user.Name = entity.Name;
                user.Surname = entity.Surname;
                user.Company = entity.Company;
            }
            context.SaveChanges();
        }
    }
}
