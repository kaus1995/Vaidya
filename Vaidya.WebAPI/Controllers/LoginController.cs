using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vaidya.WebAPI.Models;

namespace Vaidya.WebAPI.Controllers
{
    public class LoginController : ApiController
    {
        //[ActionName("XAMARIN_REG")]
        //public HttpResponseMessage Xamarin_reg(string username, string password)
        [HttpPost]
        [Route("api/Xamarin_reg")]
        public HttpResponseMessage Xamarin_reg(Contact c)
        {
            using (KVaidyaDBEntities db = new KVaidyaDBEntities())
            {
                var id = db.Contacts.Max(x => (int?)x.ID);

                Contact contact = new Contact();
                contact.ID = id.HasValue ? id.Value + 1 : 1;
                contact.Email = c.Email;
                contact.Password = c.Password;
                contact.FirstName = c.FirstName;
                contact.LastName = c.LastName;
                contact.DOB = c.DOB;
                contact.Address = c.Address;
                contact.PhoneNumber = c.PhoneNumber;
                db.Contacts.Add(contact);
                db.SaveChanges();
            }

            return Request.CreateResponse(HttpStatusCode.Accepted, "Successfully Created");
        }

        [HttpPost]
        [Route("api/Xamarin_login")]
        public HttpResponseMessage Xamarin_login(Contact c)
        {
            using (KVaidyaDBEntities db = new KVaidyaDBEntities())
            {
                var user = db.Contacts.Where(x => x.Email == c.Email && x.Password == c.Password).FirstOrDefault();
                if (user == null)
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, "Please Enter valid UserName and Password");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Accepted, "Success");
                }
            }
        }
    }
}
