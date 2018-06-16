using System;
using System.Collections.Generic;
using System.Text;

namespace Vaidya
{
    public partial class Contact
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Address { get; set; }
        public Nullable<int> PhoneNumber { get; set; }
    }
}
