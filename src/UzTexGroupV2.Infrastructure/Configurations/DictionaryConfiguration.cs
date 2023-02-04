using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzTexGroupV2.Domain.Entities;

namespace UzTexGroupV2.Infrastructure.Configurations;

public class DictionaryConfiguration : IEntityTypeConfiguration<LanguageDictionary>
{
    public void Configure(EntityTypeBuilder<LanguageDictionary> builder)
    {
        builder.ToTable(nameof(LanguageDictionary));

        builder.HasKey(dict => dict.Id);

        builder
            .Property(dict => dict.LanguageCode)
            .HasMaxLength(5)
            .IsRequired();
    }
}
