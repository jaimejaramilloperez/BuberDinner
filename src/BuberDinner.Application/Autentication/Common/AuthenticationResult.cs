using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Autentication.Common;

public record AuthenticationResult(
    User User,
    string Token);
