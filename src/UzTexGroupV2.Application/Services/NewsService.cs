using Microsoft.EntityFrameworkCore;
using UzTexGroupV2.Application.EntitiesDto.News;
using UzTexGroupV2.Application.MappingProfiles;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Application.Services;

public class NewsService
{
    private readonly LocalizedUnitOfWork lacalizedUnitOfWork;
    private readonly ImageRepository imageRepository;
    public NewsService(LocalizedUnitOfWork lacalizedUnitOfWork,
        ImageRepository imageRepository)
    {
        this.lacalizedUnitOfWork = lacalizedUnitOfWork;
        this.imageRepository = imageRepository;
    }

    public async ValueTask<NewsDto> CreateNewsAsync(CreateNewsDto createNews)
    {
        var imageUrl = await imageRepository.SaveImageAsync(createNews.file);

        var news = NewsMap.MapToNews(createNews, imageUrl);

        var storageNews = await this.lacalizedUnitOfWork
            .NewsRepository.CreateAsync(news);

        await this.lacalizedUnitOfWork.SaveChangesAsync();

        return NewsMap.MapToNewsDto(storageNews);
    }

    public async ValueTask<IQueryable<NewsDto>> RetrieveAllNewssAsync()
    {
        var newss = await this.lacalizedUnitOfWork.NewsRepository.GetAllAsync();

        return newss.Select(news => NewsMap.MapToNewsDto(news));
    }

    public async ValueTask<NewsDto> RetrieveNewsByIdAsync(Guid Id)
    {
        var storageNews = await GetByExpressionAsync(Id);

        return NewsMap.MapToNewsDto(storageNews);
    }

    public async ValueTask<NewsDto> ModifyNewsAsync(ModifyNewsDto modifyNewsDto)
    {
        var storageNews = await GetByExpressionAsync(modifyNewsDto.id);

        NewsMap.MapToNews(
            modifyNewsDto: modifyNewsDto,
            news: storageNews);

        var modeifiedNews = await this.lacalizedUnitOfWork.NewsRepository
            .UpdateAsync(storageNews);

        await this.lacalizedUnitOfWork.SaveChangesAsync();

        return NewsMap.MapToNewsDto(modeifiedNews);
    }
    public async ValueTask<NewsDto> DeleteNewsAsync(Guid Id)
    {
        var storageNews = await GetByExpressionAsync(Id);

        var deletedNews = await this.lacalizedUnitOfWork.NewsRepository
            .DeleteAsync(storageNews);

        await this.lacalizedUnitOfWork.SaveChangesAsync();

        return NewsMap.MapToNewsDto(deletedNews);
    }
    private async ValueTask<News> GetByExpressionAsync(Guid id)
    {
        Validations.ValidateId(id);

        var newss = await this.lacalizedUnitOfWork.NewsRepository
           .GetByExpression(expression => expression.Id == id, new string[] { });

        var news = await newss.FirstOrDefaultAsync();

        Validations.ValidateObjectForNullable(news);

        return news;
    }
}
