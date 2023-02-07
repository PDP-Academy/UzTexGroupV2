using System.ComponentModel.DataAnnotations;

namespace UzTexGroupV2.Application.EntitiesDto.News;

public record NewsDto(
    [Required(ErrorMessage =$"{nameof(UserDto.id)} berilishi kerak")]
    Guid id,

    [Required(ErrorMessage ="datetime to'g'ri kiritilishi kerak")]
    DateTime date,

    [Required(ErrorMessage =$"{nameof(NewsDto.title)} berilishi kerak")]
    string title,

    [Required(ErrorMessage =$"{nameof(NewsDto.description)} berilishi kerak")]
    string description);