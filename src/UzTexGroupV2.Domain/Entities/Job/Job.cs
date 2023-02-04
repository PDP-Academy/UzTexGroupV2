namespace UzTexGroupV2.Domain.Entities;

public class Job
{
    public Guid Id { get; set; }
    public Guid JobNameId { get; set; }
    public Guid DescriptionId { get; set; }
    public string WorkTime { get; set; }
    public decimal Salary { get; set; }
    public Guid FactoryId { get; set; }
    public Factory Factory { get; set; }
    public ICollection<LanguageDictionary> JobNames { get; set; }
    public ICollection<LanguageDictionary> Descriptions { get; set; }
    public ICollection<Application>? Applications { get; set; }
}
