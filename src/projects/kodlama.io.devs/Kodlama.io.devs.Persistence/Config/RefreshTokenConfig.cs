using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.devs.Persistence.Config;

public class RefreshTokenConfig : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("RefreshTokens")
            .HasKey(r => r.Id);

        builder.HasOne(r => r.User);

        builder.Property(r => r.Id)
            .HasColumnName("Id");

        builder.Property(r => r.UserId)
            .HasColumnName("UserId")
            .IsRequired();

        builder.Property(r => r.Token)
            .HasColumnName("Token")
            .IsRequired();

        builder.Property(r => r.Expires)
            .HasColumnName("Expires")
            .IsRequired();

        builder.Property(r => r.Created)
           .HasColumnName("Created")
           .IsRequired();
        builder.Property(r => r.CreatedByIp)
           .HasColumnName("CreatedByIp")
           .IsRequired();

        builder.Property(r => r.Revoked)
           .HasColumnName("Revoked");
        builder.Property(r => r.RevokedByIp)
           .HasColumnName("RevokedByIp");
        builder.Property(r => r.ReplacedByToken)
           .HasColumnName("ReplacedByToken");

        builder.Property(r => r.ReasonRevoked)
           .HasColumnName("ReasonRevoked");
    }
}
