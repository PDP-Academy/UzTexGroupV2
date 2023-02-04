using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzTexGroupV2.Domain.Entities;

namespace UzTexGroupV2.Infrastructure.Configurations;

public class JobConfiguration : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.ToTable(nameof(Job))
            .HasKey(job => job.Id);

        builder.Property(job => job.Salary)
            .IsRequired();

        builder.Property(job => job.WorkTime)
            .IsRequired();

        builder.HasOne(job => job.Factory)
            .WithMany(factory => factory.Jobs)
            .HasForeignKey(job => job.FactoryId);

        builder
            .HasMany(job => job.JobNames)
            .WithOne()
            .HasForeignKey(dict => dict.Id)
            .HasPrincipalKey(job => job.JobNameId);

        builder
            .HasMany(job => job.Descriptions)
            .WithOne()
            .HasForeignKey(dict => dict.Id)
            .HasPrincipalKey(job => job.DescriptionId);

    }
}
