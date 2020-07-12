using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace CH10_DividendCalendar.Security.Authorisation
{
    public class ExternalAuthorisationHandler : AuthorizationHandler<ExternalRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ExternalRequirement requirement)
        {
            if (context.User.IsInRole(Roles.External))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
