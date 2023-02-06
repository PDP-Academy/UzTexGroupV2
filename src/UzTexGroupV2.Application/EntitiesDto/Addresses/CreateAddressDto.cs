namespace UzTexGroupV2.Application.EntitiesDto.Addresses;

public record CreateAddressDto(
    string country, 
    string region,
    string district,
    string street,
    short postalCode);