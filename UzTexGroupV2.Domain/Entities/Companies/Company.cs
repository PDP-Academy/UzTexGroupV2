namespace UzTexGroupV2.Domain.Entities;

public class Company
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ICollection<Factory> Factories { get;set; }
}
