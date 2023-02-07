using Microsoft.EntityFrameworkCore;
using UzTexGroupV2.Application.EntitiesDto.Application;
using UzTexGroupV2.Application.MappingProfiles;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Application.Services;

public class ApplicationService
{
    private readonly LocalizedUnitOfWork unitOfWork;
    private readonly AddressService addressService;

    public ApplicationService(LocalizedUnitOfWork unitOfWork, AddressService addressService)
    {
        this.unitOfWork = unitOfWork;
        this.addressService = addressService;
    }

    public async ValueTask<ApplicationDto> CreateApplicationAsync(
        CreateApplicationDto createApplicationDto)
    {
        var application = ApplicationMap.MapToApplication(createApplicationDto);

        var storedAddress = await this.addressService
            .CreateAddressAsync(createApplicationDto.createAddressDto);
        
        application.AddressId = storedAddress.id;
        var storedApplication = await this.unitOfWork
            .ApplicationRepository.CreateAsync(application);

        await this.unitOfWork.SaveChangesAsync();

        return ApplicationMap.MapToApplicationDto(storedApplication);
    }

    public async ValueTask<IQueryable<ApplicationDto>> RetrieveAllApplicationsAsync()
    {
        var storageApplications = await this
            .unitOfWork.ApplicationRepository.GetAllAsync();

        return storageApplications.Select(
            application => ApplicationMap.MapToApplicationDto(application));
    }

    public async ValueTask<ApplicationDto> RetrieveApplicationByIdAsync(Guid id)
    {
        var storageApplication = await GetByExpressionAsync(id);

        return ApplicationMap.MapToApplicationDto(storageApplication);
    }

    public async ValueTask<ApplicationDto> ModifyApplicationAsync(
        ModifyApplicationDto modifyApplicationDto)
    {
        var storageApplication = await GetByExpressionAsync(modifyApplicationDto.id);

        if (modifyApplicationDto.modifyAddressDto is not null)
            await this.addressService
                .ModifyAddressAsync(modifyApplicationDto.modifyAddressDto);
        
        ApplicationMap.MapToApplication(applications: storageApplication,
            modifyApplicationDto: modifyApplicationDto);

        var modifiedApplication = await this.unitOfWork.ApplicationRepository.UpdateAsync(
            entity: storageApplication);

        await this.unitOfWork.SaveChangesAsync();

        return ApplicationMap.MapToApplicationDto(modifiedApplication);
    }

    public async ValueTask<ApplicationDto> DeleteApplicationAsync(Guid id)
    {
        var storageApplication = await GetByExpressionAsync(id);

        var deletedApplication = await this.unitOfWork.ApplicationRepository
            .DeleteAsync(storageApplication);

        await this.unitOfWork.SaveChangesAsync();

        return ApplicationMap.MapToApplicationDto(deletedApplication);
    }

    private async ValueTask<Applications> GetByExpressionAsync(Guid id)
    {
        var applications = await this.unitOfWork.ApplicationRepository
           .GetByExpression(expression => expression.Id == id);

        return await applications.FirstOrDefaultAsync();
    }
}
