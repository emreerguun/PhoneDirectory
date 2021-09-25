using PhoneDirectory.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectory.Business.Abstract
{
    public interface IContactInfoBLL
    {
        List<ContactInfoDTO> GetContactInfosByUserID(int userID);
        string AddContactInfo(ContactInfoDTO entity,int userID);
        string DeleteContactInfo(int userID,int contactID);
    }
}
