using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CH10_DividendCalendar.Security.Authorisation
{
    public class InternalAuthorisationHandler : AuthorizationHandler<InternalRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, InternalRequirement requirement)
        {
            if (context.User.IsInRole(Roles.Internal))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
