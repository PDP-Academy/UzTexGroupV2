using Microsoft.AspNetCore.Mvc;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FactoryController : LocalizedControllerBase
{
    private readonly FactoryController factoryController;
    public FactoryController(LocalizedUnitOfWork localizedUnitOfWork,
        FactoryController factoryController) : base(localizedUnitOfWork)
    {
        this.factoryController = factoryController;
    }
}
