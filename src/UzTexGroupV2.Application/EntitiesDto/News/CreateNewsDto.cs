using System.ComponentModel.DataAnnotations;
using UzTexGroupV2.Application.EntitiesDto.Company;

namespace UzTexGroupV2.Application.EntitiesDto.News;

public record CreateNewsDto : LocalizedDTO
{
    public Guid? id;

    [Required(ErrorMessage = $"{nameof(CreateNewsDto.title)}  berilishi majburiy")]
    public string title;

    [Required(ErrorMessage = $"{nameof(CreateNewsDto.description)}  berilishi majburiy")]
    public string description;
}
