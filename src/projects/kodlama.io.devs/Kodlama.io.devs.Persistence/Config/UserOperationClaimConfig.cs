using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.devs.Persistence.Config;

public class UserOperationClaimConfig : IEntityTypeConfiguration<UserOperationClaim>
{
    public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
    {
        builder.ToTable("UserOperationsClaims")
            .HasKey(u => u.Id);

        builder.HasOne(u => u.User);
        builder.HasOne(u => u.OperationClaim);

        builder.Property(p => p.Id)
            .HasColumnName("Id");

        builder.Property(u => u.UserId)
            .HasColumnName("UserId")
            .IsRequired();

        builder.Property(u => u.OperationClaimId)
            .HasColumnName("OperationClaimId")
            .IsRequired();


        builder.Property(p => p.CreatedAt)
            .HasColumnName("CreatedAt");
        builder.Property(p => p.UpdatedAt)
            .HasColumnName("UpdatedAt");
        builder.Property(p => p.DeletedAt)
            .HasColumnName("DeletedAt");

        UserOperationClaim[] userOperationClaimSeeds =
        {
            new(1,1,1),new(2,1,2)
        };
        builder.HasData(userOperationClaimSeeds);
    }
}
