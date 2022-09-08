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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
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
    }

    private void programmingLanguageEntityBuilder(ModelBuilder modelBuilder)
    {
        ProgrammingLanguage[] programmingLanguageEntitySeeds =
        {
            new(1,"C#")
        };
        modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);
    }
}
