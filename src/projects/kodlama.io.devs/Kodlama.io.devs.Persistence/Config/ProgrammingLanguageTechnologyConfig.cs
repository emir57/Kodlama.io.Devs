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
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.ProgrammingLanguageId)
            .HasColumnName("ProgrammingLanguageId")
            .IsRequired();

        builder.Property(p => p.CreatedAt)
            .HasColumnName("CreatedAt");
        builder.Property(p => p.UpdatedAt)
            .HasColumnName("UpdatedAt");
        builder.Property(p => p.DeletedAt)
            .HasColumnName("DeletedAt");

        ProgrammingLanguageTechnology[] programmingLanguageTechnologyEntitySeeds =
        {
            new(1,"Asp.Net",1,DateTime.Now),
            new(2,"Spring",2,DateTime.Now),
            new(3,"Angular",3,DateTime.Now),
            new(4,"React",3,DateTime.Now),
            new(5,"Vue",3,DateTime.Now)
        };
        builder.HasData(programmingLanguageTechnologyEntitySeeds);
    }
}
