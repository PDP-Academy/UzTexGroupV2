using Microsoft.EntityFrameworkCore;
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

    public async ValueTask<CompanyDTO> CreateCompanyAsync(
        CreateCompanyDTO createCompanyDTO)
    {
        var company = CompanyMapper
            .ToCompany(createCompanyDTO);

        var storedCompany = await unitOfWork.CompanyRepository
            .CreateAsync(company);

        await unitOfWork.SaveChangesAsync();

        return CompanyMapper
            .ToCompanyDTO(storedCompany);
    }

    public async ValueTask<IQueryable<CompanyDTO>> RetrieveAllCompnaiesAsync()
    {
        var companies = await unitOfWork
            .CompanyRepository.GetAllAsync();

        return companies.Select(company =>
            CompanyMapper.ToCompanyDTO(company));
    }

    public async ValueTask<CompanyDTO> RetrieveCompanyByIdAsync(Guid id)
    {
        var storageCompany = await GetByExpressionAsync(id);

        return CompanyMapper.ToCompanyDTO(storageCompany);
    }

    public async ValueTask<CompanyDTO> ModifyCompanyAsync(
        ModifyCompanyDTO modifyCompanyDTO)
    {
        var storageCompany = await GetByExpressionAsync(modifyCompanyDTO.Id);

        CompanyMapper.ToCompany(modifyCompanyDTO, storageCompany);

        var modifiedCompany = await this.unitOfWork
            .CompanyRepository
            .UpdateAsync(storageCompany);

        await unitOfWork.SaveChangesAsync();

        return CompanyMapper.ToCompanyDTO(modifiedCompany);
    }

    public async ValueTask<CompanyDTO> DeleteCompanyAsync(Guid id)
    {
        var storageCompany = await GetByExpressionAsync(id);

        var company = await unitOfWork.CompanyRepository
            .DeleteAsync(storageCompany);

        await unitOfWork.SaveChangesAsync();

        return CompanyMapper.ToCompanyDTO(company);
    }

    private async ValueTask<Company?> GetByExpressionAsync(Guid id)
    {
        Validations.ValidateId(id);

        var companies = await this.unitOfWork.CompanyRepository
            .GetByExpression(expression => expression.Id == id);

        Validations.ValidateObjectForNullable(companies);

        return await companies.FirstOrDefaultAsync();
    }
}