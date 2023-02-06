using UzTexGroupV2.Application.EntitiesDto;
using UzTexGroupV2.Application.MappingProfiles;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Application.Services;

public class JobService : IJobService
{
    private readonly LocalizedUnitOfWork localizedUnitOfWork;

    public JobService(LocalizedUnitOfWork localizedUnitOfWork)
    {
        this.localizedUnitOfWork = localizedUnitOfWork;
    }

    public async ValueTask<JobDto> CreateJobAsync(CreateJobDto createJobDto)
    {
        var job = JobMap.MapToJob(createJobDto);

        var storageJob = await this.localizedUnitOfWork.JobRepository
            .CreateAsync(job);

        return JobMap.MapToJobDto(storageJob);
    }

    public ValueTask<JobDto> DeleteJobAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<JobDto> ModifyJobAsync(ModifyJobDto modifyJobDto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IQueryable<JobDto>> RetrieveAllJobsAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<JobDto> RetrieveJobByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
