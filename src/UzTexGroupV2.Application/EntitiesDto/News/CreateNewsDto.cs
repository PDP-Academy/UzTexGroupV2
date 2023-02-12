using System.ComponentModel.DataAnnotations;

namespace UzTexGroupV2.Application.EntitiesDto.News;

public record CreateNewsDto(
    [Required(ErrorMessage = $"{nameof(CreateNewsDto.title)}  berilishi majburiy")]
    string title,

    [Required(ErrorMessage = $"{nameof(CreateNewsDto.description)}  berilishi majburiy")]
    string description
) : LocalizedDTO; 
