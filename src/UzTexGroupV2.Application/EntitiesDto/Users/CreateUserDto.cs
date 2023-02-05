namespace UzTexGroupV2.Application.EntitiesDto.Users;

public record CreateUserDto(
    string firstName,
    string? lastName,
    string email,
    string password);
