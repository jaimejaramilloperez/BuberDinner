using BuberDinner.Application.Autentication.Commands;
using BuberDinner.Application.Autentication.Common;
using BuberDinner.Application.Autentication.Queries;
using BuberDinner.Contracts;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("api/auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationCommandService _authorizationCommandService;
    private readonly IAuthenticationQueryService _authorizationQueryService;

    public AuthenticationController(
        IAuthenticationCommandService authorizationService,
        IAuthenticationQueryService authorizationQueryService)
    {
        _authorizationCommandService = authorizationService;
        _authorizationQueryService = authorizationQueryService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        ErrorOr<AuthenticationResult> authResult = _authorizationCommandService.Register(request.FirstName,
            request.LastName, request.Email, request.Password);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        ErrorOr<AuthenticationResult> authResult = _authorizationQueryService.Login(request.Email, request.Password);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token);
    }
}
