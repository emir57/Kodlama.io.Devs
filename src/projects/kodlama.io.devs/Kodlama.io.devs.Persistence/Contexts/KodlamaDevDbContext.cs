using Core.Persistence.Extensions;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Core.Security.Hashing;
using Kodlama.io.devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Kodlama.io.devs.Persistence.Contexts;

public class KodlamaDevDbContext : DbContext
{
    private readonly IConfigurationRoot _configuration;
    public KodlamaDevDbContext()
    {
        _configuration = new ConfigurationManager()
            .AddJsonFile("appsettings.json").Build();
    }

    public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    public DbSet<ProgrammingLanguageTechnology> ProgrammingLanguageTechnologies { get; set; }

    public DbSet<User> Users { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<GitHub> GitHubs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();


        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SqlServer"));
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
    }
}
