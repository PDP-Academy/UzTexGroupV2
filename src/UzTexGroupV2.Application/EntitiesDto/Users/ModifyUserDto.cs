using System.ComponentModel.DataAnnotations;

namespace UzTexGroupV2.Application.EntitiesDto;

public record ModifyUserDto(
    [Required(ErrorMessage =$"{nameof(ModifyUserDto.id)} berilishi kerak")]
    Guid id,

    [MaxLength(15 ,ErrorMessage ="15 ta belgidan oshmasligi kerak")]
    string? firstName,

    [MaxLength(15 ,ErrorMessage ="15 ta belgidan oshmasligi kerak")]
    string? lastName,

    [MaxLength(15 ,ErrorMessage ="15 ta belgidan oshmasligi kerak")]
    string? email);
