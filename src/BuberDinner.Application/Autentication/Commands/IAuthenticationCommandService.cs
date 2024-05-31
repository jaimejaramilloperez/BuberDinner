using BuberDinner.Application.Autentication.Common;
using ErrorOr;

namespace BuberDinner.Application.Autentication.Commands;

public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
}
