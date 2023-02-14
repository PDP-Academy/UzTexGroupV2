using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UzTexGroupV2.Application.EntitiesDto;
using UzTexGroupV2.Application.Services;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Controllers;

[Route("{langCode}/api/[controller]")]
[ApiController]
public class ApplicationController : LocalizedControllerBase
{
    private readonly ApplicationService applicationService;
    public ApplicationController(LocalizedUnitOfWork localizedUnitOfWork,
        ApplicationService applicationService) : base(localizedUnitOfWork)
    {
        this.applicationService = applicationService;
    }

    [Authorize]
    [HttpPost]
    public async ValueTask<ActionResult<ApplicationDto>> PostApplicationAsync(
        CreateApplicationDto createApplicationDto)
    {
        var createdApplication = await this.applicationService
            .CreateApplicationAsync(createApplicationDto);

        return Created("", createdApplication);
    }

    [AllowAnonymous]
    [HttpGet("id: Guid")]
    public async ValueTask<ActionResult<ApplicationDto>> GetApplicationByIdAsync(
        Guid applicationId)
    {
        var Application = await this.applicationService
            .RetrieveApplicationByIdAsync(applicationId);

        return Ok(Application);
    }

    [AllowAnonymous]
    [HttpGet]
    public async ValueTask<IActionResult> GetAllApplicationesAsync()
    {
        var Applicationes = await this.applicationService
            .RetrieveAllApplicationsAsync();

        return Ok(Applicationes);
    }

    [Authorize]
    [HttpPut]
    public async ValueTask<ActionResult<ApplicationDto>> PutApplicationAsync(
        ModifyApplicationDto modifyApplicationDto)
    {
        var updatedApplication = await this.applicationService
            .ModifyApplicationAsync(modifyApplicationDto);

        return Ok(updatedApplication);
    }

    [Authorize]
    [HttpDelete("id : Guid")]
    public async ValueTask<ActionResult<ApplicationDto>> DeleteApplicationAsync(Guid id)
    {
        var deletedApplication = await this.applicationService
            .DeleteApplicationAsync(id);

        return Ok(deletedApplication);
    }
}
