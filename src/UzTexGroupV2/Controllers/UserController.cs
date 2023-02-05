using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Controllers;

public class UserController : LocalizedController
{
    public UserController(LocalizedUnitOfWork localizedUnitOfWork) : base(localizedUnitOfWork)
    {
    }
}