using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Autentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtGenerator)
    {
        _jwtTokenGenerator = jwtGenerator;
    }

    public AutenticationResult Register(string firstName, string lastName, string email, string password)
    {
        var userId = Guid.NewGuid();

        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

        return new AutenticationResult(userId, firstName, lastName, email, token);
    }

    public AutenticationResult Login(string email, string password)
    {
        return new AutenticationResult(Guid.NewGuid(), "firstName", "lastName", email, "token");
    }
}
