using Microsoft.EntityFrameworkCore;
using UzTexGroupV2.Application.EntitiesDto.News;
using UzTexGroupV2.Application.MappingProfiles;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Application.Services;

public class NewsService : IServiceBase<CreateNewsDto, NewsDto, ModifyNewsDto>
{
    private readonly LocalizedUnitOfWork lacalizedUnitOfWork;

    public NewsService(LocalizedUnitOfWork lacalizedUnitOfWork)
    {
        this.lacalizedUnitOfWork = lacalizedUnitOfWork;
    }

    public async ValueTask<NewsDto> CreateEntityAsync(CreateNewsDto entity)
    {
        var news = NewsMap.MapToNews(entity);

        var storageNews = await this.lacalizedUnitOfWork
            .NewsRepository.CreateAsync(news);

        await this.lacalizedUnitOfWork.SaveChangesAsync();

        return NewsMap.MapToNewsDto(news);
    }

    public async ValueTask<IQueryable<NewsDto>> RetrieveAllEntitiesAsync()
    {
        var newss = await this.lacalizedUnitOfWork.NewsRepository.GetAllAsync();

        return newss.Select(news => NewsMap.MapToNewsDto(news));
    }

    public async ValueTask<NewsDto> RetrieveByIdEntityAsync(Guid Id)
    {
        var news = await this.lacalizedUnitOfWork.NewsRepository
            .GetByExpression(expression => expression.Id == Id);

        var storageNews = await news.FirstOrDefaultAsync();

        return NewsMap.MapToNewsDto(storageNews);
    }

    public async ValueTask<NewsDto> ModifyEntityAsync(ModifyNewsDto modifyNewsDto)
    {
        var news = await this.lacalizedUnitOfWork.NewsRepository
            .GetByExpression(expression => expression.Id == modifyNewsDto.id);

        var storageNews = await news.FirstOrDefaultAsync();

        NewsMap.MapToNews(
            modifyNewsDto: modifyNewsDto,
            news: storageNews);

        var modeifiedNews = await this.lacalizedUnitOfWork.NewsRepository
            .UpdateAsync(storageNews);
        await this.lacalizedUnitOfWork.SaveChangesAsync();

        return NewsMap.MapToNewsDto(modeifiedNews);
    }
    public async ValueTask<NewsDto> DeleteEntityAsync(Guid Id)
    {
        var news = await this.lacalizedUnitOfWork.NewsRepository
            .GetByExpression(expression => expression.Id == Id);

        var storageNews = await news.FirstOrDefaultAsync();

        var deletedNews = await this.lacalizedUnitOfWork.NewsRepository
            .DeleteAsync(storageNews);

        await this.lacalizedUnitOfWork.SaveChangesAsync();

        return NewsMap.MapToNewsDto(deletedNews);
    }

}
