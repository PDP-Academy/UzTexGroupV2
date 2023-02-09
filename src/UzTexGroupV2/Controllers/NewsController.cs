using Microsoft.AspNetCore.Mvc;
using UzTexGroupV2.Application.Services;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NewsController : LocalizedControllerBase
{
    private readonly NewsService newsService;
    public NewsController(LocalizedUnitOfWork localizedUnitOfWork,
        NewsService newsService) : base(localizedUnitOfWork)
    {
        this.newsService = newsService;
    }
}
