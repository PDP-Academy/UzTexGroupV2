using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzTexGroupV2.Domain.Entities;

namespace UzTexGroupV2.Infrastructure.Configurations;

public class DictionaryConfiguration : IEntityTypeConfiguration<Dictionary>
{
    public void Configure(EntityTypeBuilder<Dictionary> builder)
    {
        builder.ToTable(nameof(Dictionary));

        builder.HasKey(dict => dict.Id);

        builder
            .Property(dict => dict.LanguageCode)
            .HasMaxLength(5)
            .IsRequired();

        builder
            .Property(dict => dict.Content)
            .IsRequired();
    }
}
