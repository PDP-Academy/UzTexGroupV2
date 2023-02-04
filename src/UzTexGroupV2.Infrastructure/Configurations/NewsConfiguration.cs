using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzTexGroupV2.Domain.Entities;

namespace UzTexGroupV2.Infrastructure.Configurations;

public class NewsConfiguration : IEntityTypeConfiguration<News>
{
    public void Configure(EntityTypeBuilder<News> builder)
    {
        builder.ToTable(nameof(News));
        
        builder.HasKey(news => news.Id);
        
        builder
            .Property(news => news.Date)
            .IsRequired();
        
        builder
            .HasMany(news => news.Titles)
            .WithOne()
            .HasForeignKey(dictionary => dictionary.Id)
            .HasPrincipalKey(news => news.TitleId)
            .IsRequired();
            
        builder
            .HasMany(news => news.Descriptions)
            .WithOne()
            .HasForeignKey(dictionary => dictionary.Id)
            .HasPrincipalKey(news => news.DescriptionId)
            .IsRequired();
        

        // builder
        //     .Property(news => news.Images)
        //     .IsRequired();
    }
}
