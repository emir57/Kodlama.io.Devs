using Core.Persistence.Extensions;
using Core.Persistence.Repositories;
using Kodlama.io.devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Kodlama.io.devs.Persistence.Contexts;

public class KodlamaDevDbContext : DbContext
{
    public KodlamaDevDbContext()
    {

    }

    public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    public DbSet<ProgrammingLanguageTechnology> ProgrammingLanguageTechnologies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();

        IConfigurationBuilder configurationBuilder = new ConfigurationManager()
            .AddJsonFile("appsettings.json");
        
        optionsBuilder.UseSqlServer(configurationBuilder.GetConnectionString("SqlServer"));
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<EntityEntry<Entity>> entries = ChangeTracker.Entries<Entity>();
        entries.SetStateDate();

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        programmingLanguageEntityBuilder(modelBuilder);
        programmingLanguageTechnologyEntityBuilder(modelBuilder);
    }

    private void programmingLanguageEntityBuilder(ModelBuilder modelBuilder)
    {
        ProgrammingLanguage[] programmingLanguageEntitySeeds =
        {
            new(1,"C#"),
            new(2,"Java"),
            new(3,"JavaScript")
        };
        modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);
    }
    private void programmingLanguageTechnologyEntityBuilder(ModelBuilder modelBuilder)
    {
        ProgrammingLanguageTechnology[] programmingLanguageTechnologyEntitySeeds =
        {
            new(1,"Asp.Net",1),
            new(2,"Spring",2),
            new(3,"Angular",3),
            new(4,"React",3),
            new(5,"Vue",3)
        };
        modelBuilder.Entity<ProgrammingLanguageTechnology>().HasData(programmingLanguageTechnologyEntitySeeds);
    }
}
