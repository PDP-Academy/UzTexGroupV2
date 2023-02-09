using Microsoft.AspNetCore.Mvc;
using UzTexGroupV2.Application.EntitiesDto.Addresses;
using UzTexGroupV2.Application.EntitiesDto.News;
using UzTexGroupV2.Application.Services;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Controllers;

[Route("api/news")]
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
        Guid id)
    {
        var News = await this.newsService
            .RetrieveNewsByIdAsync(id);

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
    public async ValueTask<ActionResult<NewsDto>> UpdateNewsAsync(
        ModifyNewsDto modifyNewsDto)
    {
        var updatedNews = await this.newsService
            .ModifyNewsAsync(modifyNewsDto);

        return Ok(updatedNews);
    }

    [HttpDelete("id : Guid")]
    public async ValueTask<ActionResult<NewsDto>> DeleteAdressAsync(Guid id)
    {
        var deletedAdress = await this.newsService
            .DeleteNewsAsync(id);
        return Ok(deletedAdress);
    }
}
