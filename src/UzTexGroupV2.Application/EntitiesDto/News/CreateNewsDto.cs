namespace UzTexGroupV2.Application.EntitiesDto.News;

public record CreateNewsDto : LocalizedDTO
{
    public Guid? id;
    public string title;
    public string description;
}
