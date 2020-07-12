using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCuttingConcerns.Security
{
    public readonly struct Credentials
    {
        public static string Role { get; private set; }

        public Credentials(string username, string password)
        {
            switch (username)
            {
                case "System" when password == "Administrator":
                    Role = "Administrator";
                    break;
                case "End" when password == "User":
                    Role = "Restricted";
                    break;
                default:
                    Role = "Imposter";
                    break;
            }
        }
    }
}
