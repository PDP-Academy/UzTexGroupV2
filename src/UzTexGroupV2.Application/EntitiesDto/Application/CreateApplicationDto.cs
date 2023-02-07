using System.ComponentModel.DataAnnotations;
using UzTexGroupV2.Application.EntitiesDto.Addresses;

namespace UzTexGroupV2.Application.EntitiesDto.Application;

public record CreateApplicationDto(
    [Required]
    [MaxLength(30)]
    string firstName,

    [MaxLength(50)]
    string? lastName,

    [Required]
    [MaxLength(15)]
    string phoneNumber,

    [Required]
    [MaxLength(300)]
    string applicationMassage,

    [Required]
    [EmailAddress]
    string email,

    [Required]
    Guid jobId,

    [Required]
    CreateAddressDto createAddressDto);
