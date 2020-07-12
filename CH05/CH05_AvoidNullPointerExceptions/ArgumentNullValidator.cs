using System;

namespace CH05_AvoidNullPointerExceptions
{
    internal static class ArgumentNullValidator
    {
        public static void NotNull(string name, [ValidatedNotNull] object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}
