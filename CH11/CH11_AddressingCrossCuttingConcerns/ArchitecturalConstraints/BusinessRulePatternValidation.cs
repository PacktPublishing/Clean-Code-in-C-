using PostSharp.Constraints;
using PostSharp.Extensibility;
using System;

namespace CH11_AddressingCrossCuttingConcerns.ArchitecturalConstraints
{
    [MulticastAttributeUsage(MulticastTargets.Class, Inheritance = MulticastInheritance.Strict)]
    public class BusinessRulePatternValidation : ScalarConstraint
    {
        public override void ValidateCode(object target)
        {
            var targetType = (Type)target;

            if (targetType.GetNestedType("Factory") == null)
            {
                Message.Write(
                    targetType, SeverityType.Warning,
                    "2001",
                    $"The {target.GetType().Name} type does not have a nested type named 'Factory'.",
                    targetType.DeclaringType,
                    targetType.Name);
            }
        }
    }
}
