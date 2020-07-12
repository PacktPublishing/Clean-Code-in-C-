using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CH13_CodeRefactoring.ProblemCode
{
    public class Authorization
    {
        private Authentication _authentication;

        public Authorization(Authentication authentication)
        {
            _authentication = authentication;
        }

        public void Login(ICredentials credentials)
        {
            _authentication.Login(credentials);
        }

        public void Logout()
        {
            _authentication.Logout();
        }

        public bool IsAuthenticated()
        {
            return _authentication.IsAuthenticated();
        }

        public bool IsAuthorized(string role)
        {
            return role.Contains("Administrator");
        }
    }
}
