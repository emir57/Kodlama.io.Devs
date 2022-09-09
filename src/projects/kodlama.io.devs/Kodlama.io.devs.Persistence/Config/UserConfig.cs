using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.devs.Persistence.Config;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User")
            .HasKey(u => u.Id);

        builder.HasMany(u => u.RefreshTokens);
        builder.HasMany(u => u.UserOperationClaims);

        builder.Property(u => u.FirstName)
            .HasColumnName("FirstName")
            .HasMaxLength(50);

        builder.Property(u => u.LastName)
            .HasColumnName("LastName")
            .HasMaxLength(50);

        builder.Property(u => u.Email)
            .HasColumnName("Email")
            .HasMaxLength(50);

        builder.Property(u => u.PasswordHash)
            .HasColumnName("PasswordHash");
        builder.Property(u => u.PasswordSalt)
            .HasColumnName("PasswordSalt");

        builder.Property(u => u.Status)
            .HasColumnName("Status");

        builder.Property(u => u.AuthenticatorType)
            .HasColumnName("AuthenticatorType");
    }
}
