using Microsoft.EntityFrameworkCore;
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
    public async ValueTask<IQueryable<CompanyDTO>> RetrieveAllCompaniesAsync()
    {
        var companies = await unitOfWork
            .CompanyRepository
            .GetAllAsync();

        return companies.Select(company =>
        CompanyMapper.ToCompanyDTO(company));
    }
    public async ValueTask<CompanyDTO> RetrieveCompanyByIdAsync(Guid id)
    {
        var storageCompanies = await this.unitOfWork
            .CompanyRepository
            .GetByExpression(expression: company =>
            company.Id == id);

        var storageCompany = await storageCompanies
            .FirstOrDefaultAsync();

        return CompanyMapper.ToCompanyDTO(storageCompany);
    }
    public async ValueTask<CompanyDTO> ModifyCompanyAsync(ModifyCompanyDTO modifyCompanyDTO)
    {
        var storageCompanies = await this.unitOfWork
            .CompanyRepository
            .GetByExpression(expression: company =>
            company.Id == modifyCompanyDTO.Id);

        var storageCompany = await storageCompanies
            .FirstOrDefaultAsync();

        CompanyMapper.ToCompany(modifyCompanyDTO, storageCompany);

        var modifiedCompany = await this.unitOfWork
            .CompanyRepository
            .UpdateAsync(storageCompany);

        await unitOfWork.SaveChangesAsync();

        return CompanyMapper.ToCompanyDTO(modifiedCompany);
    }
    public async ValueTask<CompanyDTO> DeleteCompanyAsync(Guid id)
    {
        var companies = await this.unitOfWork
            .CompanyRepository
            .GetByExpression(expression: company =>
            company.Id == id);

        var storageCompany = await companies
            .FirstOrDefaultAsync();

        var company = await unitOfWork.CompanyRepository
            .DeleteAsync(storageCompany);

        await unitOfWork.SaveChangesAsync();

        return CompanyMapper.ToCompanyDTO(company);
    }
}
