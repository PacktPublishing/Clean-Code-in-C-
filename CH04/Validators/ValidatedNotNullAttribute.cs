using System;

namespace CH4.Validators
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    internal sealed class ValidatedNotNullAttribute : Attribute
    {
    }
}
