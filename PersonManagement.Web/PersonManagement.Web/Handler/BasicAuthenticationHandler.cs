using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PersonManagement.Services.Abstractions;
using PersonManagement.Services.Models.User;
using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace PersonManagement.Web.Handler
{
    //public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    //{
    //    private readonly IUserService _service;

    //    public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
    //                                        ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock
    //                                        , IUserService service) : base(options, logger, encoder, clock)
    //    {
    //        _service = service;
    //    }

    //    protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
    //    {
    //        var endpoint = Context.GetEndpoint();

    //        if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
    //        {
    //            return await Task.FromResult(AuthenticateResult.NoResult());
    //        }

    //        if (!Request.Headers.ContainsKey("Authorization"))
    //        {
    //            return await Task.FromResult(AuthenticateResult.Fail("Missing Auth Header"));
    //        }

    //        UserServiceModel user = null;

    //        try
    //        {
    //            //var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
    //            //var credentialBytes = Convert.FromBase64String(authHeader.Parameter);

    //            //var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);

    //            //var username = credentials[0];
    //            //var password = credentials[1];

    //            //var result = await _service.AuthenticateAsync(username, password);

    //            //user = result;
    //            //if (user == null)
    //            //{
    //            //    return AuthenticateResult.Fail("Incorrect username or password");
    //            //}
    //        }
    //        catch (Exception ex)
    //        {
    //            return AuthenticateResult.Fail("Missing Auth Header");
    //        }

    //        var claims = new[]
    //        {
    //            new Claim(ClaimTypes.Name, user.UserName),
    //            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
    //            new Claim("postiction", "admin"),
    //        };

    //        var identity = new ClaimsIdentity(claims, Scheme.Name);

    //        var pricnipal = new ClaimsPrincipal(identity);
    //        var ticket = new AuthenticationTicket(pricnipal, Scheme.Name);

    //        return AuthenticateResult.Success(ticket);
    //    }
    //}
}
