using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH4
{
    public struct Credential
    {
        public Credential(string email, string password)
        {
            EmailAddress = email;
            Password = password;
        }

        public string EmailAddress { get; }
        public string Password { get; }
    }
}
