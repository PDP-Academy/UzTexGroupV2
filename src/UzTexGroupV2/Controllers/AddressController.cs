using Microsoft.AspNetCore.Mvc;
using UzTexGroupV2.Application.EntitiesDto.Addresses;
using UzTexGroupV2.Application.Services;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Controllers;

[Route("/{api}/address")]
[ApiController]
public class AddressController : LocalizedControllerBase
{
    private readonly AddressService addressService;
    public AddressController(LocalizedUnitOfWork localizedUnitOfWork,
        AddressService addressService) : base(localizedUnitOfWork)
    {
        this.addressService = addressService;
    }

    [HttpPost]
    public async ValueTask<ActionResult<AddressDto>> PostAddressAsync(
        CreateAddressDto createAddressDto)
    {
        var createdAddress = await this.addressService
            .CreateAddressAsync(createAddressDto);

        return Created("", createdAddress);
    }

    [HttpGet("id: Guid")]
    public async ValueTask<ActionResult<AddressDto>> GetAddressByIdAsync(
        Guid id)
    {
        var address = await this.addressService
            .RetrieveAddressByIdAsync(id); 

        return Ok(address);
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetallAddressesAsync()
    {
        var addresses = await this.addressService
            .RetrieveAllAdressesAsync();

        return Ok(addresses);
    }

    [HttpPut]
    public async ValueTask<ActionResult<AddressDto>> UpdateAddressAsync(
        ModifyAddressDto modifyAddressDto)
    {
        var updatedAddress = await this.addressService
            .ModifyAddressAsync(modifyAddressDto);

        return Ok(updatedAddress);
    }

    [HttpDelete("id : Guid")]
    public async ValueTask<ActionResult<AddressDto>> DeleteAdressAsync(Guid id)
    {
        var deletedAdress = await this.addressService
            .DeleteAddressAsync(id);
        return Ok(deletedAdress);
    }
}
