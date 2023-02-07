namespace UzTexGroupV2.Application.EntitiesDto.Addresses;
public record ModifyAddressDto(
    Guid addressId,
    string? country,
    string? region,
    string? district,
    string? street,
    short? postalCode);
