using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace WebDev.Authorization;
public class AuthorizationConventions : IControllerModelConvention
{
    public const string PolicyName = nameof(AuthorizationConventions);
    public void Apply(ControllerModel controller)
    {
        if (controller == null && controller.ControllerName != "Login")
        {
            controller.Filters.Add(new AuthorizeFilter());
        }
    }
}
