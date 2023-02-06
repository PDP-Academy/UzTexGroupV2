using Microsoft.EntityFrameworkCore;
using UzTexGroupV2.Application.EntitiesDto.Application;
using UzTexGroupV2.Application.MappingProfiles;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Application.Services;

public class ApplicationService : IApplicationService
{
    private readonly UnitOfWork unitOfWork;

    public ApplicationService(UnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async ValueTask<ApplicationDto> CreateApplicationAsync(
        CreateApplicationDto createApplicationDto)
    {
        var storageApplication = ApplicationMap.MapToApplication(createApplicationDto);
        var storageAdress = AddressMap.MapToAddress(createApplicationDto.createAddressDto);

        await unitOfWork.AddressRepository.CreateAsync(storageAdress);

        var application = await this.unitOfWork.ApplicationRepository
            .CreateAsync(storageApplication);
        await this.unitOfWork.SaveChangesAsync();

        return ApplicationMap.MapToApplicationDto(application);
    }

    public async ValueTask<IQueryable<ApplicationDto>> RetrieveAllApplicationsAsync()
    {
        var storageApplications = await this.unitOfWork.ApplicationRepository.GetAllAsync();

        return storageApplications.Select(
            application => ApplicationMap.MapToApplicationDto(application));
    }

    public async ValueTask<ApplicationDto> RetrieveApplicationByIdAsync(Guid id)
    {
        var storageApplications = await this.unitOfWork.ApplicationRepository.GetByExpression(
            app => app.Id == id);

        return ApplicationMap.MapToApplicationDto(await storageApplications.FirstOrDefaultAsync());
    }

    public async ValueTask<ApplicationDto> ModifyApplicationAsync(
        ModifyApplicationDto modifyApplicationDto)
    {
        var storageApplications = await this.unitOfWork.ApplicationRepository.GetByExpression(
                    app => app.Id == modifyApplicationDto.id);

        var selectedApplication = await storageApplications.FirstOrDefaultAsync();

        ApplicationMap.MapToApplication(applications: selectedApplication,
            modifyApplicationDto: modifyApplicationDto);

        var application = await this.unitOfWork.ApplicationRepository.UpdateAsync(
            entity: selectedApplication);

        await this.unitOfWork.SaveChangesAsync();

        return ApplicationMap.MapToApplicationDto(application);
    }

    public async ValueTask<ApplicationDto> DeleteApplicationAsync(Guid id)
    {
        var storageApplications = await this.unitOfWork.ApplicationRepository.GetByExpression(
                    app => app.Id == id);

        var selectedApplication = await storageApplications.FirstOrDefaultAsync();

        var deletedApplication = await this.unitOfWork.ApplicationRepository
            .DeleteAsync(selectedApplication);

        return ApplicationMap.MapToApplicationDto(deletedApplication);
    }
}
