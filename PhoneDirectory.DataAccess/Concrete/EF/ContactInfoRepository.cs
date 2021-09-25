using PhoneDirectory.DataAccess.Abstract;
using PhoneDirectory.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneDirectory.DataAccess.Concrete.EF
{
    public class ContactInfoRepository : IContactInfoRepository
    {
        private PhoneDirectoryContext context;
        public ContactInfoRepository(PhoneDirectoryContext _context)
        {
            context = _context;
        }
        public List<ContactInfo> GetContactInfosByUserID(int userID)
        {
            return context.ContactInfos.Where(x => x.UserID == userID).ToList();
        }

        public int AddContactInfo(ContactInfo entity)
        {
            context.ContactInfos.Add(entity);
            return context.SaveChanges();
        }

        public int DeleteContactInfo(int userID,int contactID)
        {
            List<ContactInfo> contactInfo = GetContactInfosByUserID(userID);
            if (contactInfo.Count != 0)
            {
                foreach (var info in contactInfo)
                {
                    if (info.ContactInfoID==contactID)
                    {
                        context.Remove(info);
                    }
                }
                return context.SaveChanges();
            }
            else return 0;
        }
    }
}
