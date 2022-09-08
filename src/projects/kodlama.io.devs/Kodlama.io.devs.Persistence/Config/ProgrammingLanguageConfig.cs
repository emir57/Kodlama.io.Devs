﻿using Kodlama.io.devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.devs.Persistence.Config;

public class ProgrammingLanguageConfig : IEntityTypeConfiguration<ProgrammingLanguage>
{
    public void Configure(EntityTypeBuilder<ProgrammingLanguage> builder)
    {
        builder.ToTable("ProgrammingLanguages")
            .HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("Id");

        builder.Property(p => p.Name)
            .HasColumnName("Name")
            .HasMaxLength(50);
    }
}
