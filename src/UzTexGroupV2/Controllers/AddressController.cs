using Microsoft.AspNetCore.Mvc;
using UzTexGroupV2.Application.Services;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressController : LocalizedControllerBase
{
    private readonly AddressService addressService;
    public AddressController(LocalizedUnitOfWork localizedUnitOfWork,
        AddressService addressService) : base(localizedUnitOfWork)
    {
        this.addressService = addressService;
    }

}
