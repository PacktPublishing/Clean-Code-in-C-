using PostSharp.Patterns.Diagnostics;
using PostSharp.Extensibility;
using PostSharp.Patterns.Diagnostics.Audit;

[assembly: Log(AttributePriority = 1, AttributeTargetMemberAttributes = MulticastAttributes.Protected | MulticastAttributes.Internal | MulticastAttributes.Public)]
[assembly: Log(AttributePriority = 2, AttributeExclude = true, AttributeTargetMembers = "get_*")]
[assembly: Audit(AttributePriority = 1, AttributeTargetTypes = "CH11_AddressingCrossCuttingConcerns.*", AttributeTargetMemberAttributes = MulticastAttributes.Public)]
[assembly: Audit(AttributePriority = 2, AttributeExclude = true, AttributeTargetMembers = "get_*")]
namespace CH11_AddressingCrossCuttingConcerns.Aspects
{
    public class GlobalAspects
    {
    }
}
