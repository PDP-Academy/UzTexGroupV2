using UzTexGroupV2.Application.EntitiesDto;

namespace UzTexGroupV2.Application.Services;

public interface IJobService 
{
    ValueTask<JobDto> CreateJobAsync(CreateJobDto createJobDto);
    ValueTask<IQueryable<JobDto>> RetrieveAllJobsAsync();
    ValueTask<JobDto> RetrieveJobByIdAsync(Guid id);
    ValueTask<JobDto> ModifyJobAsync(ModifyJobDto modifyJobDto);
    ValueTask<JobDto> DeleteJobAsync(Guid id);
}
