using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Controllers;

public class UserController : LocalizedControllerBase
{
    public UserController(LocalizedUnitOfWork localizedUnitOfWork) : base(localizedUnitOfWork)
    {
    }

    public List<int> GetData()
    {
        return new List<int>(){1, 2, 3};
    }
}