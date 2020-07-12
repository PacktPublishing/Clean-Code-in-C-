using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GoodCodeBadCode.RegEx
{
    public static class RegularExpressionExtensions
    {
        public static bool IsValidEmail(this string email)
        {
            var exp = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            bool isEmail = Regex.IsMatch(email, exp, RegexOptions.IgnoreCase);
            return isEmail;
        }
    }
}
