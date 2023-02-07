using Microsoft.EntityFrameworkCore;
using UzTexGroupV2.Application.EntitiesDto;
using UzTexGroupV2.Application.MappingProfiles;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Application.Services;

public class JobService : IServiceBase<CreateJobDto, JobDto, ModifyJobDto>
{
    private readonly LocalizedUnitOfWork localizedUnitOfWork;

    public JobService(LocalizedUnitOfWork localizedUnitOfWork)
    {
        this.localizedUnitOfWork = localizedUnitOfWork;
    }

    public async ValueTask<JobDto> CreateEntityAsync(CreateJobDto createJobDto)
    {
        var job = JobMap.MapToJob(createJobDto);

        var storageJob = await this.localizedUnitOfWork
            .JobRepository.CreateAsync(job);

        await this.localizedUnitOfWork.SaveChangesAsync();

        return JobMap.MapToJobDto(storageJob);
    }

    public async ValueTask<IQueryable<JobDto>> RetrieveAllEntitiesAsync()
    {
        var jobs = await this.localizedUnitOfWork.JobRepository
            .GetAllAsync();

        return jobs.Select(job => JobMap.MapToJobDto(job));
    }

    public async ValueTask<JobDto> RetrieveByIdEntityAsync(Guid id)
    {
        var storageJob = await GetByExpressionAsync(id);

        return JobMap.MapToJobDto(storageJob);
    }

    public async ValueTask<JobDto> ModifyEntityAsync(ModifyJobDto modifyJobDto)
    {
        var storageJob = await GetByExpressionAsync(modifyJobDto.Id);

        var job = await this.localizedUnitOfWork.JobRepository.UpdateAsync(storageJob);

        await this.localizedUnitOfWork.SaveChangesAsync();

        return JobMap.MapToJobDto(job : job);
    }

    public async ValueTask<JobDto> DeleteEntityAsync(Guid id)
    {
        var storageJob = await GetByExpressionAsync(id);

        var deletedJob = await this.localizedUnitOfWork.JobRepository.DeleteAsync(storageJob);

        await this.localizedUnitOfWork.SaveChangesAsync();

        return JobMap.MapToJobDto(deletedJob);
    }
    private async ValueTask<Job> GetByExpressionAsync(Guid id)
    {
        var jobs = await this.localizedUnitOfWork.JobRepository
           .GetByExpression(expression => expression.Id == id);

        return await jobs.FirstOrDefaultAsync();
    }
}
