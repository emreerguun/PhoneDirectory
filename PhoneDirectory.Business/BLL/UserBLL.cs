using PhoneDirectory.Business.Abstract;
using PhoneDirectory.DataAccess.Abstract;
using PhoneDirectory.Entities.Entities;
using PhoneDirectory.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using PhoneDirectory.Business.Models;
using System.Linq;

namespace PhoneDirectory.Business.BLL
{
    public class UserBLL : IUserBLL
    {
        private IUserRepository userRepository;
        private IContactInfoRepository contactInfoRepository;
        public UserBLL(IUserRepository _userRepository, IContactInfoRepository _contactInfoRepository)
        {
            userRepository = _userRepository;
            contactInfoRepository = _contactInfoRepository;
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
            if (user != null)
            {
                return new UserDTO() { Name = user.Name, Surname = user.Surname, Company = user.Company };
            }
            else return null;
        }
        public UserDetail UserDetail(UserDTO userDTO, List<ContactInfoDTO> contactInfoDTO)
        {
            if (userDTO != null && contactInfoDTO != null)
            {
                UserDetail userDetail = new UserDetail() { User = userDTO, ContactInfos = contactInfoDTO };
                return userDetail;
            }
            return null;

        }
        public string AddUser(UserDTO userDto)
        {
            string message;
            int result = 0;
            result = userRepository.AddUser(new User() { Name = userDto.Name, Surname = userDto.Surname, Company = userDto.Company });
            if (result == 1)
            {
                message = "Kişi Ekleme Başarılı";
            }
            else message = "Kişi Ekleme Başarısız";
            return message;
        }

        public string UpdateUser(UserDTO userDto, int userID)
        {
            string message;
            int result = 0;
            User user = userRepository.GetUserByID(userID);
            if (user != null)
            {
                user = new User() { Name = userDto.Name, Surname = userDto.Surname, Company = userDto.Company };
                result = userRepository.UpdateUser(user);
                if (result == 1)
                {
                    message = "Kişi Güncelleme Başarılı";
                }
                else message = "Kişi Güncelleme Başarısız";
            }
            else message = "Kişi Bulunamadı";
            return message;
        }


        public string DeleteUser(int userID)
        {
            string message;
            int result = 0;
            User user = userRepository.GetUserByID(userID);
            if (user != null)
            {
                result = userRepository.DeleteUser(userID);
                if (result == 1)
                {
                    message = "Kişi Silme Başarılı";
                }
                else message = "Kişi Silme Başarısız";
            }
            else message = "Kişi Bulunamadı";
            return message;
        }

        public List<LocationReport> DescendingLocationByUser(int userID)
        {
            List<LocationReport> locationReport = new List<LocationReport>();
            List<ContactInfo> contactInfos = contactInfoRepository.GetContactInfosByUserID(userID);
            List<ContactInfo> locations = new List<ContactInfo>();
            foreach (var info in contactInfos)
            {
                if (info.InfoType == 2)
                {
                    locations.Add(info);
                }
            }
            foreach (var loc in locations)
            {
                int control = 0;
                if (locations.IndexOf(loc) == 0)
                {
                    locationReport.Add(new LocationReport() { Location = loc.InfoContent,Sum=1 });
                }
                else
                {
                    foreach (var rep in locationReport)
                    {
                        if (rep.Location==loc.InfoContent)
                        {
                            rep.Sum++;
                            control = 1;
                        }
                    }
                    if (control!=1)
                    {
                        locationReport.Add(new LocationReport() { Location = loc.InfoContent, Sum = 1 });
                    }
                }
            }
            locationReport = locationReport.OrderByDescending(x=>x.Sum).ToList();
            return locationReport;
        }
    }
}