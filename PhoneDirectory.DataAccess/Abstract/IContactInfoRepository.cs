using PhoneDirectory.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectory.DataAccess.Abstract
{
    public interface IContactInfoRepository
    {
        ContactInfo GetContactInfoByID(int contactID);
        void AddContactInfo(ContactInfo entity);
        void UpdateContactInfo(ContactInfo entity);
        void DeleteContactInfo(int contactID);
    }
}
