namespace UzTexGroupV2.Application.EntitiesDto.Company;

public record CreateCompanyDTO : LocalizedDTO
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
}
