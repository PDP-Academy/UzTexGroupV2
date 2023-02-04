using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzTexGroupV2.Domain.Entities;

namespace UzTexGroupV2.Infrastructure.Configurations;

public class FactoryConfiguration : IEntityTypeConfiguration<Factory>
{
    public void Configure(EntityTypeBuilder<Factory> builder)
    {
        builder.ToTable(nameof(Factory))
            .HasKey(factory => factory.Id);

        builder
            .HasMany(factory => factory.Names)
            .WithOne()
            .HasForeignKey(dictionary => dictionary.Id)
            .HasPrincipalKey(factory => factory.NameTextId)
            .IsRequired();

        builder
            .HasOne(factory => factory.Company)
            .WithMany(company => company.Factories)
            .HasForeignKey(factory => factory.CompanyId);

        builder
            .HasOne(factory => factory.Address)
            .WithOne()
            .HasForeignKey<Factory>(factory => factory.AddressId);

    }
}
