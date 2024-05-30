using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Autentication;

public record AuthenticationResult(
    User User,
    string Token);
