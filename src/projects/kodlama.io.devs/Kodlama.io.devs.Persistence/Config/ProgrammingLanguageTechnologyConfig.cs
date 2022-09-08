using Kodlama.io.devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.devs.Persistence.Config;

public class ProgrammingLanguageTechnologyConfig : IEntityTypeConfiguration<ProgrammingLanguageTechnology>
{
    public void Configure(EntityTypeBuilder<ProgrammingLanguageTechnology> builder)
    {
        builder.ToTable("ProgrammingLanguageTechnologies")
            .HasKey(p => p.Id);

        builder.HasOne(p => p.ProgrammingLanguage);

        builder.Property(p => p.Id)
            .HasColumnName("Id");

        builder.Property(p => p.Name)
            .HasColumnName("Name")
            .HasMaxLength(50);

        builder.Property(p => p.CreatedAt)
            .HasColumnName("CreatedAt");
        builder.Property(p => p.UpdatedAt)
            .HasColumnName("UpdatedAt");
        builder.Property(p => p.DeletedAt)
            .HasColumnName("DeletedAt");
    }
}
