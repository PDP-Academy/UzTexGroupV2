namespace UzTexGroupV2.Application.EntitiesDto;

public record ModifyUserDto(
    Guid id,
    string? firstName,
    string? lastName,
    string? email);
