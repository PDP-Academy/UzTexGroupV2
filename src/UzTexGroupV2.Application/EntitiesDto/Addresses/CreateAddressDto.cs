namespace UzTexGroupV2.Application.EntitiesDto.Addresses;

public record CreateAddressDto(
    Guid Id,
    string Country, 
    string Region,
    string District,
    string Street,
    short PostalCode);