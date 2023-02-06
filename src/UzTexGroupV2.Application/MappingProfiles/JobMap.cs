using UzTexGroupV2.Application.EntitiesDto;
using UzTexGroupV2.Application.EntitiesDto.Factory;
using UzTexGroupV2.Application.EntitiesDto.Job;
using UzTexGroupV2.Domain.Entities;

namespace UzTexGroupV2.Application.MappingProfiles;

public static class JobMap
{
    internal static Job MapToJob(CreateJobDto createJobDto)
    {
        return new Job
        {
            Id = createJobDto.Id ?? Guid.NewGuid(),
            Name = createJobDto.Name,
            Desription = createJobDto.Desription,
            Salary = createJobDto.Salary,
            WorkTime = createJobDto.WorkTime,
            LanguageCode = createJobDto.LanguageCode,
            FactoryId = createJobDto.FactoryId
        };
    }
    public static JobDto MapToJobDto(Job job)
    {
        return new JobDto
        (
            id :job.Id,
            name : job.Name,
            description : job.Desription,
            salary : job.Salary,
            workTime : job.WorkTime,
            factoryDto : null

        );
    }
}
