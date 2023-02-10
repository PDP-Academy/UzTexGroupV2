using Microsoft.AspNetCore.Mvc;
using UzTexGroupV2.Application.EntitiesDto.Addresses;
using UzTexGroupV2.Application.EntitiesDto.News;
using UzTexGroupV2.Application.Services;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Controllers;

[Route("{langCode}/api/[controller]")]
[ApiController]
public class NewsController : LocalizedControllerBase
{
    private readonly NewsService newsService;
    public NewsController(LocalizedUnitOfWork localizedUnitOfWork,
        NewsService newsService) : base(localizedUnitOfWork)
    {
        this.newsService = newsService;
    }
    [HttpPost]
    public async ValueTask<ActionResult<NewsDto>> PostNewsAsync(
        CreateNewsDto createNewsDto)
    {
        var createdNews = await this.newsService
            .CreateNewsAsync(createNewsDto);

        return Created("", createdNews);
    }

    [HttpGet("id: Guid")]
    public async ValueTask<ActionResult<NewsDto>> GetNewsByIdAsync(
        Guid newsId)
    {
        var News = await this.newsService
            .RetrieveNewsByIdAsync(newsId);

        return Ok(News);
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetallNewsesAsync()
    {
        var Newses = await this.newsService
            .RetrieveAllNewssAsync();

        return Ok(Newses);
    }

    [HttpPut]
    public async ValueTask<ActionResult<NewsDto>> PutNewsAsync(
        ModifyNewsDto modifyNewsDto)
    {
        var updatedNews = await this.newsService
            .ModifyNewsAsync(modifyNewsDto);

        return Ok(updatedNews);
    }

    [HttpDelete("id : Guid")]
    public async ValueTask<ActionResult<NewsDto>> DeleteAdressAsync(Guid newsId)
    {
        var deletedAdress = await this.newsService
            .DeleteNewsAsync(newsId);
        return Ok(deletedAdress);
    }
}
