using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace WebDevAPI.Configuration;

public class ApiKeyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public ApiKeyAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder) : base(options, logger, encoder)
    {
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var apiKey = Request.Headers.FirstOrDefault(o => o.Key == "WebDev-api-key");

        if (apiKey.Value == "adcdefg")
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "Admin")
            };

            var identity = new ClaimsIdentity(claims, ApiKeyAuthenticationSheme.SchemeName);

            var principal = new ClaimsPrincipal(identity);

            var ticket = new AuthenticationTicket(principal, ApiKeyAuthenticationSheme.SchemeName);

            return AuthenticateResult.Success(ticket);
        }
        else
        {
            return AuthenticateResult.Fail("Api key is wrong");
        }
    }
}
