namespace UzTexGroupV2.Application.Entities.Users;

public record ModifyUserDto(
    string? firstName,
    string? lastName,
    string? password,
    string? email);
