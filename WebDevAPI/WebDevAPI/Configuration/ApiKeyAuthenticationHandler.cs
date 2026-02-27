using DataAccess.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace WebDevAPI.Configuration;

public class ApiKeyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly string _apiKey;
    public ApiKeyAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder, IConfiguration configuration) : base(options, logger, encoder)
    {
        _apiKey = configuration["ApiSettings:ApiKey"];
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var apiKey = Request.Headers.FirstOrDefault(o => o.Key == "WebDev-api-key");

        if (apiKey.Value == _apiKey)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "User")
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
