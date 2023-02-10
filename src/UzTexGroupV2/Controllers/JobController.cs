using Microsoft.AspNetCore.Mvc;
using UzTexGroupV2.Application.EntitiesDto;
using UzTexGroupV2.Application.EntitiesDto.Addresses;
using UzTexGroupV2.Application.Services;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Controllers;

[Route("{langCode}/api/[controller]")]
[ApiController]
public class JobController : LocalizedControllerBase
{
    private readonly JobService jobService;
    public JobController(LocalizedUnitOfWork localizedUnitOfWork,
        JobService jobService) : base(localizedUnitOfWork)
    {
        this.jobService = jobService;
    }

    [HttpPost]
    public async ValueTask<ActionResult<JobDto>> PostJobAsync(
        CreateJobDto createJobDto)
    {
        var createdJob = await this.jobService
            .CreateJobAsync(createJobDto);

        return Created("", createdJob);
    }

    [HttpGet("id: Guid")]
    public async ValueTask<ActionResult<JobDto>> GetJobByIdAsync(
        Guid jobId)
    {
        var Job = await this.jobService
            .RetrieveJobByIdAsync(jobId);

        return Ok(Job);
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetallJobesAsync()
    {
        var jobs = await this.jobService
            .RetrieveAllJobsAsync();

        return Ok(jobs);
    }

    [HttpPut]
    public async ValueTask<ActionResult<JobDto>> PutJobAsync(
        ModifyJobDto modifyJobDto)
    {
        var updatedJob = await this.jobService
            .ModifyJobAsync(modifyJobDto);

        return Ok(updatedJob);
    }

    [HttpDelete("id : Guid")]
    public async ValueTask<ActionResult<JobDto>> DeleteAdressAsync(Guid jobId)
    {
        var deletedAdress = await this.jobService
            .DeleteJobAsync(jobId);
        return Ok(deletedAdress);
    }
}
