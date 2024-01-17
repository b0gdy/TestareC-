using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace TestareC_.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger, UrlEncoder encoder,
            ISystemClock clock
        ) : base(options, logger, encoder, clock) { }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("No authorization in the request!");
            }

            string authorizationHeader = Request.Headers["Authorization"];

            if (string.IsNullOrEmpty(authorizationHeader))
            {
                return AuthenticateResult.Fail("Authorization header empty!");
            }

            if (!authorizationHeader.StartsWith("basic ", StringComparison.OrdinalIgnoreCase))
            {
                return AuthenticateResult.Fail("Authorization is not basic!");
            }

            var token = authorizationHeader.Substring(6);
            var credentialAsString = Encoding.UTF8.GetString(Convert.FromBase64String(token));

            var credentials = credentialAsString.Split(":");
            if (credentials?.Length != 2)
            {
                return AuthenticateResult.Fail("Username or password missing!");
            }
            var username = credentials[0];
            var password = credentials[1];

            if (username != "user" && password != "password")
            {
                return AuthenticateResult.Fail("Username or password incorrect!");
            }
        
            var claims = new[] { new Claim(ClaimTypes.NameIdentifier, username) };
            
            var identity = new ClaimsIdentity(claims, "BasicAuthentication");
            var claimsPrincipal = new ClaimsPrincipal(identity);
            
            return AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name));

        }




    }
}
