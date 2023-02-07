using System.ComponentModel.DataAnnotations;

namespace UzTexGroupV2.Application.EntitiesDto.Addresses;
public record AddressDto(
    [Required] 
     Guid id,

    [Required()]
    [MaxLength(50)]
    
    string country,

    [Required]
    [MaxLength(100)]
    string region,

    [Required]
    [MaxLength(100)]
    string district,

    [Required]
    [MaxLength(100)]
    string street,

    [Required]
    short postalCode);