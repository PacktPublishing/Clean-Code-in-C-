using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH4.Validators
{
    internal static  class ArgumentValidator
    {
        public static void NotNull(string name, [ValidatedNotNull] object value)
        {
            if (value == null)
                throw new ArgumentNullException(name);
        }
    }
}
