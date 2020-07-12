using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace CrossCuttingConcerns.Security
{
    public class ConcreteDecorator : DecoratorBase
    {
        public ConcreteDecorator(ISecureComponent secureComponent) : base(secureComponent)
        {
        }

        public override void AddData(dynamic data)
        {
            if (Credentials.Role.Contains("Administrator") || Credentials.Role.Contains("Restricted"))
            {
                base.AddData((object)data);
            }
            else
            {
                throw new UnauthorizedAccessException("Unauthorized");
            }
        }

        public override int EditData(dynamic data)
        {
            if (Credentials.Role.Contains("Administrator") || Credentials.Role.Contains("Restricted"))
            {
                return base.EditData((object)data);
            }
            else
            {
                throw new UnauthorizedAccessException("Unauthorized");
            }
        }

        public override int DeleteData(dynamic data)
        {
            if (Credentials.Role.Contains("Administrator"))
            {
                return base.DeleteData((object)data);
            }
            else
            {
                throw new UnauthorizedAccessException("Unauthorized");
            }
        }

        public override dynamic GetData(dynamic data)
        {
            if (Credentials.Role.Contains("Administrator") || Credentials.Role.Contains("Restricted"))
            {
                return base.GetData((object)data);
            }
            else
            {
                throw new UnauthorizedAccessException("Unauthorized");
            }
        }
    }
}
