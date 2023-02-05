using UzTexGroupV2.Application.EntitiesDto.Company;
using UzTexGroupV2.Domain.Entities;

namespace UzTexGroupV2.Application.MappingProfiles;

public static class CompanyMapper
{
    public static CompanyDTO ToCompanyDTO(Company company)
    {
        return new CompanyDTO
        {
            Id = company.Id,
            Name = company.Name,
        };
    }

    public static Company ToCompany(CreateCompanyDTO createCompanyDTO)
    {
        return new Company
        {
            Id = createCompanyDTO.Id ?? Guid.NewGuid(),
            LanguageCode = createCompanyDTO.LanguageCode,
            Name = createCompanyDTO.Name,
        };
    }
}
