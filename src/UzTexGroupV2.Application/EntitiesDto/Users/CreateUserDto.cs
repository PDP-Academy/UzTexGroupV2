namespace UzTexGroupV2.Application.Entities.Users;

public record CreateUserDto(
    string firstName,
    string? lastName,
    string email,
    string password);
