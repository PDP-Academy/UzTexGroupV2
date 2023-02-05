namespace UzTexGroupV2.Application.EntitiesDto.Addresses;
public record AddressDto(
    Guid Id,
    string Country,
    string Region,
    string District,
    string Street,
    short PostalCode);