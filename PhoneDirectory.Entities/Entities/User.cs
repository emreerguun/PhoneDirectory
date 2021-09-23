using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectory.Entities.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }

        public List<ContactInfo> ContactInfos { get; set; }
    }
}
