using System.ComponentModel.DataAnnotations;

namespace UzTexGroupV2.Application.EntitiesDto.News;

public record ModifyNewsDto
{
    [Required(ErrorMessage = $"{nameof(ModifyNewsDto.id)}  berilishi majburiy")]
    public Guid id;

    public string? title;
    public string? description;
}
