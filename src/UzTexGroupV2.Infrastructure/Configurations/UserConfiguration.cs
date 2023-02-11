using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzTexGroupV2.Domain.Entities;

namespace UzTexGroupV2.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));

        builder.HasKey(user => user.Id);

        builder
            .Property(user => user.FirstName)
            .HasMaxLength(50)
            .IsRequired();
        
        builder
            .Property(user => user.LastName)
            .HasMaxLength(50)
            .IsRequired(false);

        builder
            .HasIndex(user => user.Email)
            .IsUnique();

        builder
            .Property(user => user.PasswordHash)
            .IsRequired();

        builder
            .Property(user => user.UserRole)
            .IsRequired();

    }
}
