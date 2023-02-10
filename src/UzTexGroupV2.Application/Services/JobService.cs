using Microsoft.EntityFrameworkCore;
using UzTexGroupV2.Application.EntitiesDto;
using UzTexGroupV2.Application.MappingProfiles;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Application.Services;

public class JobService
{
    private readonly LocalizedUnitOfWork localizedUnitOfWork;

    public JobService(LocalizedUnitOfWork localizedUnitOfWork)
    {
        this.localizedUnitOfWork = localizedUnitOfWork;
    }

    public async ValueTask<JobDto> CreateJobAsync(CreateJobDto createJobDto)
    {
        var job = JobMap.MapToJob(createJobDto);

        var storedJob = await this.localizedUnitOfWork
            .JobRepository.CreateAsync(job);

        await this.localizedUnitOfWork.SaveChangesAsync();

        return JobMap.MapToJobDto(storedJob);
    }

    public async ValueTask<IQueryable<JobDto>> RetrieveAllJobsAsync()
    {
        var jobs = await this.localizedUnitOfWork.JobRepository
            .GetAllAsync();

        return jobs.Select(job => JobMap.MapToJobDto(job));
    }

    public async ValueTask<JobDto> RetrieveJobByIdAsync(Guid id)
    {
        var storageJob = await GetByExpressionAsync(id);

        return JobMap.MapToJobDto(storageJob);
    }

    public async ValueTask<JobDto> ModifyJobAsync(ModifyJobDto modifyJobDto)
    {
        var storageJob = await GetByExpressionAsync(modifyJobDto.Id);

        var job = await this.localizedUnitOfWork.JobRepository
            .UpdateAsync(storageJob);

        await this.localizedUnitOfWork.SaveChangesAsync();

        return JobMap.MapToJobDto(job : job);
    }

    public async ValueTask<JobDto> DeleteJobAsync(Guid id)
    {
        var storageJob = await GetByExpressionAsync(id);

        var deletedJob = await this.localizedUnitOfWork.JobRepository
            .DeleteAsync(storageJob);

        await this.localizedUnitOfWork.SaveChangesAsync();

        return JobMap.MapToJobDto(deletedJob);
    }
    private async ValueTask<Job> GetByExpressionAsync(Guid id)
    {
        Validations.ValidateId(id);

        var jobs = await this.localizedUnitOfWork.JobRepository
           .GetByExpression(expression => expression.Id == id);

        Validations.ValidateObject(jobs);

        return await jobs.FirstOrDefaultAsync();
    }
}
