namespace UzTexGroupV2.Domain.Entities;

public class Company
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public IList<Company> Companies { get;set; }
}
