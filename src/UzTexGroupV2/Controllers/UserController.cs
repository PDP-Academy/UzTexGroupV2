using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UzTexGroupV2.Application.Services;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Filters;
using UzTexGroupV2.Infrastructure.Repositories;
using UzTexGroupV2.Model;

namespace UzTexGroupV2.Controllers;

[Controller]
[Route("/{langCode}/[controller]")]
public class UserController : LocalizedControllerBase
{
    public UserController(LocalizedUnitOfWork localizedUnitOfWork, UserService service) : base(localizedUnitOfWork)
    {
    }

    [HttpGet]
    [ResponeFilter]
    public List<int> GetData()
    {
        Console.WriteLine(base.Request.RouteValues["langCode"]);

        return new List<int>() { 1, 2, 3 };
    }
}
