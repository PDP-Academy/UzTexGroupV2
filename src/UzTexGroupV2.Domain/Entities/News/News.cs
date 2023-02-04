namespace UzTexGroupV2.Domain.Entities;

public class News
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public Guid TitleId { get; set; }
    public Guid DescriptionId { get; set; }

    public ICollection<LanguageDictionary> Titles { get; set; }
    public ICollection<LanguageDictionary> Descriptions { get; set; }
    public ICollection<NewsImages> Images { get;}
}
