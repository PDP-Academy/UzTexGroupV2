//using Microsoft.AspNetCore.Mvc;
//using UzTexGroupV2.Application.EntitiesDto.Factory;
//using UzTexGroupV2.Application.Services;
//using UzTexGroupV2.Infrastructure.Repositories;

//namespace UzTexGroupV2.Controllers;

//[Route("api/factory")]
//[ApiController]
//public class FactoryController : LocalizedControllerBase
//{
//    private readonly FactoryService factoryService;
//    public FactoryController(LocalizedUnitOfWork localizedUnitOfWork,
//        FactoryService factoryService) : base(localizedUnitOfWork)
//    {
//        this.factoryService = factoryService;
//    }

//    [HttpPost]
//    public async ValueTask<ActionResult<FactoryDto>> PostFactoryAsync(
//        CreateFactoryDto createFactoryDto)
//    {
//        var createdFactory = await this.factoryService
//            .CreateFactoryAsync(createFactoryDto);

//        return Created("", createdFactory);
//    }

//    [HttpGet("id: Guid")]
//    public async ValueTask<ActionResult<FactoryDto>> GetFactoryByIdAsync(
//        Guid id)
//    {
//        var factory = await this.factoryService
//            .RetrieveFactoryByIdAsync(id);

//        return Ok(factory);
//    }

//    [HttpGet]
//    public async ValueTask<IActionResult> GetallFactoryesAsync()
//    {
//        var factories = await this.factoryService
//            .RetrieveAllFactoriesAsync();

//        return Ok(factories);
//    }

//    [HttpPut]
//    public async ValueTask<ActionResult<FactoryDto>> UpdateFactoryAsync(
//        ModifyFactoryDto modifyfactoryDto)
//    {
//        var updatedfactory = await this.factoryService
//            .ModifyFactoryAsync(modifyfactoryDto);

//        return Ok(updatedfactory);
//    }

//    [HttpDelete("id : Guid")]
//    public async ValueTask<ActionResult<FactoryDto>> DeleteFactoryAsync(Guid id)
//    {
//        var deletedAdress = await this.factoryService
//            .DeleteFactoryAsync(id);
//        return Ok(deletedAdress);
//    }
//}
