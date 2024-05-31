using BuberDinner.Application.Autentication.Common;
using ErrorOr;

namespace BuberDinner.Application.Autentication.Queries;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
}
