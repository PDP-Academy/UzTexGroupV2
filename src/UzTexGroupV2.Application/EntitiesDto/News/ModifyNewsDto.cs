namespace UzTexGroupV2.Application.EntitiesDto.News;

public record ModifyNewsDto(
    Guid id,
    string? title,
    string? description);
