using PhoneDirectory.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectory.Business.Models
{
    public class UserDetail
    {
        public UserDTO User { get; set; }
        public List<ContactInfoDTO> ContactInfos { get; set; }
    }
}
