using System.ComponentModel.DataAnnotations;

namespace UzTexGroupV2.Application.EntitiesDto.News;

public record CreateNewsDto : LocalizedDTO
{
    [Required(ErrorMessage = $"{nameof(CreateNewsDto.title)}  berilishi majburiy")]
    public string title;

    [Required(ErrorMessage = $"{nameof(CreateNewsDto.description)}  berilishi majburiy")]
    public string description;
}
