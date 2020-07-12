using System;

namespace CrossCuttingConcerns.Validation
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.Property)]
    public class AllowNullAttribute : Attribute
    {
    }
}
