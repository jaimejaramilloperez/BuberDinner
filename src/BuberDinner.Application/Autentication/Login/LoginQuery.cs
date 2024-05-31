using BuberDinner.Application.Autentication.Common;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Autentication.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
