using Microsoft.EntityFrameworkCore;
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

        await this.localizedUnitOfWork.SaveChangesAsync();

        return JobMap.MapToJobDto(storageJob);
    }

    public async ValueTask<IQueryable<JobDto>> RetrieveAllJobsAsync()
    {
        var jobs = await this.localizedUnitOfWork.JobRepository
            .GetAllAsync();

        return jobs.Select(job => JobMap.MapToJobDto(job));
    }

    public async ValueTask<JobDto> RetrieveJobByIdAsync(Guid id)
    {
        var jobs = await this.localizedUnitOfWork.JobRepository
            .GetByExpression(expression: job => job.Id == id);

        var storageJob = await jobs.FirstOrDefaultAsync();

        return JobMap.MapToJobDto(storageJob);
    }

    public async ValueTask<JobDto> ModifyJobAsync(ModifyJobDto modifyJobDto)
    {
        var jobs = await this.localizedUnitOfWork.JobRepository
            .GetByExpression(expression: job => job.Id == modifyJobDto.Id);

        var storageJob = await jobs.FirstOrDefaultAsync();

        var job = await this.localizedUnitOfWork.JobRepository.UpdateAsync(storageJob);

        await this.localizedUnitOfWork.SaveChangesAsync();

        return JobMap.MapToJobDto(job : job);
    }

    public async ValueTask<JobDto> DeleteJobAsync(Guid id)
    {
        var jobs = await this.localizedUnitOfWork.JobRepository
            .GetByExpression(expression: job => job.Id == id);

        var storageJob = await jobs.FirstOrDefaultAsync();

        var deletedJob = await this.localizedUnitOfWork.JobRepository.DeleteAsync(storageJob);

        return JobMap.MapToJobDto(deletedJob);
    }
}
