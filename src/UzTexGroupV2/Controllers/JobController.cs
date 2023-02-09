using Microsoft.AspNetCore.Mvc;
using UzTexGroupV2.Application.Services;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobController : LocalizedControllerBase
{
    private readonly JobService jobService;
    public JobController(LocalizedUnitOfWork localizedUnitOfWork,
        JobService jobService) : base(localizedUnitOfWork)
    {
        this.jobService = jobService;
    }
}
