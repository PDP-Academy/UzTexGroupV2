using Microsoft.AspNetCore.Mvc;
using UzTexGroupV2.Application.Services;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : LocalizedControllerBase
{
    private readonly CompanyService companyService;
    public CompanyController(LocalizedUnitOfWork localizedUnitOfWork,
        CompanyService companyService) : base(localizedUnitOfWork)
    {
        this.companyService = companyService;
    }
}
