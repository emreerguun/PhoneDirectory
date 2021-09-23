using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhoneDirectory.Entities.Entities
{
    public class User
    {
        public User()
        {
            ContactInfos = new HashSet<ContactInfo>();
        }


        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }

        public virtual ICollection<ContactInfo> ContactInfos { get; set; }
    }
}
