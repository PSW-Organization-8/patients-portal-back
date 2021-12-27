using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.SharedModel
{
    public class Contact
    {
        public string Email { get; set; }
        public string Phone { get; set; }

        public Contact()
        {

        }

        public Contact(string email, string phone)
        {
            Email = email;
            Phone = phone;
        }
    }
}
