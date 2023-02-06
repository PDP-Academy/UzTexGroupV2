using UzTexGroupV2.Application.EntitiesDto.Addresses;

namespace UzTexGroupV2.Application.EntitiesDto.Application;

public record CreateApplicationDto(
    string firstName,
    string? lastName,
    string phoneNumber,
    string applicationMassage,
    string email,
    Guid jobId,
    string Country,
    string Region,
    string District,
    string Street,
    short PostalCode);
