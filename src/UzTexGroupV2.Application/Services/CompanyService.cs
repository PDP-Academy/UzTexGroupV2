using UzTexGroupV2.Application.EntitiesDto;
using UzTexGroupV2.Application.EntitiesDto.Company;
using UzTexGroupV2.Application.MappingProfiles;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Application.Services;

public class CompanyService
{
    private readonly LocalizedUnitOfWork unitOfWork;

    public CompanyService(LocalizedUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async ValueTask<CompanyDTO> CreateEntityAsync<TEntry, TReturn>(CreateCompanyDTO createCompanyDTO)
    {

        var company = CompanyMapper
            .ToCompany(createCompanyDTO);

        await unitOfWork
            .CompanyRepository
            .CreateAsync(company);

        await unitOfWork
            .SaveChangesAsync();

        return CompanyMapper
            .ToCompanyDTO(company);
    }

}
