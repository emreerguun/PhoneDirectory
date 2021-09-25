using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneDirectory.Business.Abstract;
using PhoneDirectory.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectory.WebApi.Controllers
{
    [ApiController]
    [Route("api/contactinfos")]
    public class ContactInfoController : ControllerBase
    {
        private IContactInfoBLL contactInfoBLL;
        public ContactInfoController(IContactInfoBLL _contactInfoBLL)
        {
            contactInfoBLL = _contactInfoBLL;
        }

        [HttpGet("{userID}")]
        public List<ContactInfoDTO> GetContactInfosByUserID(int userID)
        {
            return contactInfoBLL.GetContactInfosByUserID(userID);
        }

        [HttpPost("addcontactinfo/{userID}")]
        public string AddContactInfo(ContactInfoDTO contactInfoDTO, int userID)
        {
            return contactInfoBLL.AddContactInfo(contactInfoDTO, userID);
        }
        [HttpDelete("deletecontactinfo/{userID}/{contactID}")]
        public string DeleteContactInfo(int userID,int contactID)
        {
            return contactInfoBLL.DeleteContactInfo(userID,contactID);
        }
    }
}
