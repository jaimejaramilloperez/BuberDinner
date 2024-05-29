namespace BuberDinner.Application.Autentication;

public record AutenticationResult(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token);
