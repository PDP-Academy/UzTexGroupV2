namespace UzTexGroupV2.Application.EntitiesDto.Company;

public record ModifyCompanyDTO : LocalizedDTO
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}