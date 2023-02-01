namespace UzTexGroupV2.Domain.Entities;

public class News
{
    public Guid Id { get; set; }
    public DateOnly Date { get; set; }
    public Guid TitleId { get; set; }
    public Guid DescriptionId { get; set; }

    public ICollection<Dictionary> Titles { get; set; }
    public ICollection<Dictionary> Descriptions { get; set; }
    public ICollection<NewsImages> Images { get;}
}
