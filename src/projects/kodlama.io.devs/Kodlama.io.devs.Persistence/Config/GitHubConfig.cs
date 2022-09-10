using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.devs.Persistence.Config;

public class GitHubConfig : IEntityTypeConfiguration<GitHub>
{
    public void Configure(EntityTypeBuilder<GitHub> builder)
    {
        builder.ToTable("GitHubs")
            .HasKey(g => g.Id);

        builder.HasOne(g => g.User);

        builder.Property(g => g.Id)
            .HasColumnName("Id");

        builder.Property(g => g.ProfileUserName)
            .HasColumnName("ProfileUserName")
            .HasMaxLength(50);

        builder.Ignore(g => g.ProfileUrl);
    }
}
