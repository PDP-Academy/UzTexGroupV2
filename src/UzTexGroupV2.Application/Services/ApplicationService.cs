using Microsoft.EntityFrameworkCore;
using UzTexGroupV2.Application.EntitiesDto.Application;
using UzTexGroupV2.Application.MappingProfiles;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Application.Services;

public class ApplicationService : IServiceBase<CreateApplicationDto, ApplicationDto,ModifyApplicationDto>
{
    private readonly UnitOfWork unitOfWork;

    public ApplicationService(UnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async ValueTask<ApplicationDto> CreateEntityAsync(
        CreateApplicationDto createApplicationDto)
    {
        var storageApplication = ApplicationMap.MapToApplication(createApplicationDto);

        var storageAdress = AddressMap.MapToAddress(
            createApplicationDto.createAddressDto,
            storageApplication.AddressId);

        await unitOfWork.AddressRepository.CreateAsync(storageAdress);

        var application = await this.unitOfWork
            .ApplicationRepository.CreateAsync(storageApplication);

        await this.unitOfWork.SaveChangesAsync();

        return ApplicationMap.MapToApplicationDto(application);
    }

    public async ValueTask<IQueryable<ApplicationDto>> RetrieveAllEntitiesAsync()
    {
        var storageApplications = await this
            .unitOfWork.ApplicationRepository.GetAllAsync();

        return storageApplications.Select(
            application => ApplicationMap.MapToApplicationDto(application));
    }

    public async ValueTask<ApplicationDto> RetrieveByIdEntityAsync(Guid id)
    {
        var storageApplication = await GetByExpressionAsync(id);

        return ApplicationMap.MapToApplicationDto(storageApplication);
    }

    public async ValueTask<ApplicationDto> ModifyEntityAsync(
        ModifyApplicationDto modifyApplicationDto)
    {
        var storageApplication = await GetByExpressionAsync(modifyApplicationDto.id);


        ApplicationMap.MapToApplication(applications: storageApplication,
            modifyApplicationDto: modifyApplicationDto);

        var application = await this.unitOfWork.ApplicationRepository.UpdateAsync(
            entity: storageApplication);

        await this.unitOfWork.SaveChangesAsync();

        return ApplicationMap.MapToApplicationDto(application);
    }

    public async ValueTask<ApplicationDto> DeleteEntityAsync(Guid id)
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
