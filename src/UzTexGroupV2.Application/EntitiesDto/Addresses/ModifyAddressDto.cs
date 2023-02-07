using System.ComponentModel.DataAnnotations;

namespace UzTexGroupV2.Application.EntitiesDto.Addresses;
public record ModifyAddressDto(
    [Required]
    Guid addressId,

    [MaxLength(50)]
    string? country,

    [MaxLength(100)]
    string? region,

    [MaxLength(100)]
    string? district,

    [MaxLength(100)]
    string? street,

    short? postalCode);
