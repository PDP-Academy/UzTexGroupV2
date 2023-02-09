using Microsoft.AspNetCore.Mvc;
using UzTexGroupV2.Application.EntitiesDto.Company;
using UzTexGroupV2.Application.Services;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Controllers;

[Route("api/company")]
[ApiController]
public class CompanyController : LocalizedControllerBase
{
    private readonly CompanyService companyService;
    public CompanyController(LocalizedUnitOfWork localizedUnitOfWork,
        CompanyService companyService) : base(localizedUnitOfWork)
    {
        this.companyService = companyService;
    }

    [HttpPost]
    public async ValueTask<ActionResult<CompanyDTO>> PostCompanyAsync(
        CreateCompanyDTO createCompanyDTO)
    {
        var createdCompany = await this.companyService
            .CreateCompanyAsync(createCompanyDTO);

        return Created("", createdCompany);
    }

    [HttpGet("id: Guid")]
    public async ValueTask<ActionResult<CompanyDTO>> GetCompanyByIdAsync(
        Guid id)
    {
        var company = await this.companyService
            .RetrieveCompanyByIdAsync(id);

        return Ok(company);
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetallCompaniesAsync()
    {
        var companies = await this.companyService
            .RetrieveAllCompnaiesAsync();

        return Ok(companies);
    }

    [HttpPut]
    public async ValueTask<ActionResult<CompanyDTO>> UpdateCompanyAsync(
        ModifyCompanyDTO modifyCompanyDTO)
    {
        var updatedCompany = await this.companyService
            .ModifyCompanyAsync(modifyCompanyDTO);

        return Ok(updatedCompany);
    }

    [HttpDelete("id : Guid")]
    public async ValueTask<ActionResult<CompanyDTO>> DeleteAdressAsync(Guid id)
    {
        var deletedAdress = await this.companyService
            .DeleteCompanyAsync(id);
        return Ok(deletedAdress);
    }
}
