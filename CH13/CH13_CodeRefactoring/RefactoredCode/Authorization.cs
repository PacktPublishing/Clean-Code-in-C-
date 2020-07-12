using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CH13_CodeRefactoring.RefactoredCode
{
    public class Authorization
    {
        private ProblemCode.Authentication _authentication;

        public Authorization(ProblemCode.Authentication authentication)
        {
            _authentication = authentication;
        }

        public bool IsAuthorized(string role)
        {
            return _authentication.IsAuthenticated() && role.Contains("Administrator");
        }
    }
}
