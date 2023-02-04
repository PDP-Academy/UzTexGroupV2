using System.Collections;

namespace UzTexGroupV2.Domain.Entities;

public class Factory
{
    public Guid Id { get; set; }
    public Guid NameTextId { get; set; }
    public ICollection<LanguageDictionary> Names { get; set; }
    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }
    public Guid AddressId { get; set; }
    public Address Address { get; set; }
    public ICollection<Job>? Jobs { get; set; }
}
