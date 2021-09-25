using PhoneDirectory.Business.Abstract;
using PhoneDirectory.Business.DTO;
using PhoneDirectory.DataAccess.Abstract;
using PhoneDirectory.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectory.Business.BLL
{
    public class ContactInfoBLL : IContactInfoBLL
    {
        private IContactInfoRepository contactInfoRepository;
        private IUserRepository userRepository;
        public ContactInfoBLL(IContactInfoRepository _contactInfoRepository, IUserRepository _userRepository)
        {
            contactInfoRepository = _contactInfoRepository;
            userRepository = _userRepository;
        }

        public List<ContactInfoDTO> GetContactInfosByUserID(int userID)
        {
            List<ContactInfoDTO> contactInfoDTO = new List<ContactInfoDTO>();
            List<ContactInfo> contactInfos = contactInfoRepository.GetContactInfosByUserID(userID);
            if (contactInfos.Count != 0)
            {
                foreach (var info in contactInfos)
                {
                    contactInfoDTO.Add(new ContactInfoDTO() { InfoType = info.InfoType, InfoContent = info.InfoContent });
                }
                return contactInfoDTO;
            }
            else return null;
        }
        public string AddContactInfo(ContactInfoDTO contactInfoDTO, int userID)
        {
            string message;
            int result = 0;
            User user = userRepository.GetUserByID(userID);
            if (user != null)
            {
                result = contactInfoRepository.AddContactInfo(new ContactInfo() { InfoType = contactInfoDTO.InfoType, InfoContent = contactInfoDTO.InfoContent, UserID = userID });
                if (result == 1)
                {
                    message = "Kişi Bilgisi Ekleme Başarılı";
                }
                else message = "Kişi Bilgisi Ekleme Başarısız";
            }
            else message = "Kişi Bulunamadı";
            return message;
        }

        public string DeleteContactInfo(int userID, int contactID)
        {
            string message;
            int result = 0;
            User user = userRepository.GetUserByID(userID);
            if (user != null)
            {
                result = contactInfoRepository.DeleteContactInfo(userID, contactID);
                if (result == 1)
                {
                    message = "Kişi Bilgisi Silme Başarılı";
                }
                else message = "Kişi Bilgisi Silme Başarısız";
            }
            else message = "Kişi Bulunamadı";
            return message;
        }
    }
}
