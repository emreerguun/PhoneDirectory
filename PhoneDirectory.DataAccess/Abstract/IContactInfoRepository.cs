using PhoneDirectory.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectory.DataAccess.Abstract
{
    public interface IContactInfoRepository
    {
        List<ContactInfo> GetContactInfosByUserID(int userID);
        int AddContactInfo(ContactInfo entity);
        int DeleteContactInfo(int userID,int contactID);
    }
}
