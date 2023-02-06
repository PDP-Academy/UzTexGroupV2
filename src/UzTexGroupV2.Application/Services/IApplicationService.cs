using UzTexGroupV2.Application.EntitiesDto.Application;
using UzTexGroupV2.Application.EntitiesDto.Company;

namespace UzTexGroupV2.Application.Services;

public interface IApplicationService
{
    ValueTask<ApplicationDto> CreateApplicationAsync(CreateApplicationDto createApplicationDto);
    ValueTask<IQueryable<ApplicationDto>> RetrieveAllApplicationsAsync();
    ValueTask<ApplicationDto> RetrieveApplicationByIdAsync(Guid id);
    ValueTask<ApplicationDto> ModifyApplicationAsync(ModifyApplicationDto modifyApplicationDto);
    ValueTask<ApplicationDto> DeleteApplicationAsync(Guid id);
}
