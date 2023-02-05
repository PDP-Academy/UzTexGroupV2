namespace UzTexGroupV2.Application.EntitiesDto;

public record CreateUserDto(
    Guid? id,
    string firstName,
    string? lastName,
    string email,
    string password);
