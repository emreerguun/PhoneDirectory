using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectory.Entities.Entities
{
    public class ContactInfo
    {
        public int ContactInfoID { get; set; }
        public int InfoType { get; set; }
        public string InfoContent { get; set; }


        public int UserID { get; set; }

        public User User { get; set; }
    }
}
