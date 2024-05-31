using BuberDinner.Application.Autentication.Common;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Autentication.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
