using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.devs.Persistence.Config;

public class OperationClaimConfig : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims")
            .HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .HasColumnName("Id");

        builder.Property(o => o.Name)
            .HasColumnName("Name")
            .IsRequired()
            .HasMaxLength(50);
    }
}
