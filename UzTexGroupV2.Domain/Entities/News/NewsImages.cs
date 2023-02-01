namespace UzTexGroupV2.Domain.Entities;

public class NewsImages
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; }
    public Guid NewId { get; set; }
    public News News { get; set; }
}
