using Microsoft.AspNetCore.Mvc;
using UzTexGroupV2.Application.Services;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationController : LocalizedControllerBase
{
    private readonly ApplicationService applicationService;
    public ApplicationController(LocalizedUnitOfWork localizedUnitOfWork,
        ApplicationService applicationService) : base(localizedUnitOfWork)
    {
        this.applicationService = applicationService;
    }
}
