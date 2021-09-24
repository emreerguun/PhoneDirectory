using PhoneDirectory.Business.Abstract;
using PhoneDirectory.DataAccess.Abstract;
using PhoneDirectory.Entities.Entities;
using PhoneDirectory.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectory.Business.BLL
{
    public class UserBLL : IUserBLL
    {
        private IUserRepository userRepository;
        public UserBLL(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public List<UserDTO> GetAllUser()
        {
            List<User> users = userRepository.GetAllUser();
            List<UserDTO> usersDTO = new List<UserDTO>();
            foreach (var user in users)
            {
                usersDTO.Add(new UserDTO() { Name = user.Name, Surname = user.Surname, Company = user.Company });
            }
            return usersDTO;
        }

        public UserDTO GetUserByID(int userID)
        {
            User user = userRepository.GetUserByID(userID);
            return new UserDTO() { Name = user.Name, Surname = user.Surname, Company = user.Company };
        }

        public string AddUser(UserDTO userDto)
        {
            string message = string.Empty;
            int result = userRepository.AddUser(new User() { Name = userDto.Name, Surname = userDto.Surname, Company = userDto.Company });
            if (result == 1)
            {
                message = "Kişi Ekleme Başarılı";
            }
            else message = "Kişi Ekleme Başarısız";
            return message;
        }

        public string UpdateUser(UserDTO entity,int userID)
        {
            string message = string.Empty;
            User user = new User() { UserID=userID,Name = entity.Name, Surname = entity.Surname, Company = entity.Company };
            int result = userRepository.UpdateUser(user);
            if (result == 1)
            {
                message = "Kişi Güncelleme Başarılı";
            }
            else message = "Kişi Güncelleme Başarısız";
            return message;
        }


        public string DeleteUser(int userID)
        {
            string message = string.Empty;
            int result = userRepository.DeleteUser(userID);
            if (result == 1)
            {
                message = "Kişi Silme Başarılı";
            }
            else message = "Kişi Silme Başarısız";
            return message;
        }
    }
}
