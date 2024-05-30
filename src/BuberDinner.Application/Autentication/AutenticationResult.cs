using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Autentication;

public record AutenticationResult(
    User User,
    string Token);
