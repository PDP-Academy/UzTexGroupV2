using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzTexGroupV2.Domain.Entities;

namespace UzTexGroupV2.Infrastructure.Configurations;

public class NewsImagesConfiguration : IEntityTypeConfiguration<NewsImages>
{
    public void Configure(EntityTypeBuilder<NewsImages> builder)
    {
        builder.ToTable(nameof(NewsImages));

        builder.HasKey(img => img.Id);

        builder
            .Property(img => img.ImageUrl)
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(img => img.NewId)
            .IsRequired();

        builder
            .Property(img => img.News)
            .IsRequired(false);
    }
}
