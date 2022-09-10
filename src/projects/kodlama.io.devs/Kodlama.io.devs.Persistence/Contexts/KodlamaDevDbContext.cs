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

        programmingLanguageEntityBuilder(modelBuilder);
        programmingLanguageTechnologyEntityBuilder(modelBuilder);

        operationClaimEntityBuilder(modelBuilder);
        userEntityBuilder(modelBuilder);
        userOperationClaimEntityBuilder(modelBuilder);
    }

    private void programmingLanguageEntityBuilder(ModelBuilder modelBuilder)
    {
        ProgrammingLanguage[] programmingLanguageEntitySeeds =
        {
            new(1,"C#",DateTime.Now),
            new(2,"Java",DateTime.Now),
            new(3,"JavaScript",DateTime.Now)
        };
        modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);
    }
    private void programmingLanguageTechnologyEntityBuilder(ModelBuilder modelBuilder)
    {
        ProgrammingLanguageTechnology[] programmingLanguageTechnologyEntitySeeds =
        {
            new(1,"Asp.Net",1,DateTime.Now),
            new(2,"Spring",2,DateTime.Now),
            new(3,"Angular",3,DateTime.Now),
            new(4,"React",3,DateTime.Now),
            new(5,"Vue",3,DateTime.Now)
        };
        modelBuilder.Entity<ProgrammingLanguageTechnology>().HasData(programmingLanguageTechnologyEntitySeeds);
    }

    private void operationClaimEntityBuilder(ModelBuilder builder)
    {
        OperationClaim[] operationClaimEntitySeeds =
        {
            new(1,"User"),new(2,"Admin")
        };
        builder.Entity<OperationClaim>().HasData(operationClaimEntitySeeds);
    }
    private void userEntityBuilder(ModelBuilder builder)
    {
        User user = getUser();

        User[] userEntitySeeds =
        {
            user
        };
        builder.Entity<User>().HasData(userEntitySeeds);

        User getUser()
        {
            byte[] passwordHash, passwordSalt;
            string password = _configuration.GetSection("AdminUser:Password").Value;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            return new()
            {
                Id = 1,
                FirstName = _configuration.GetSection("AdminUser:FirstName").Value,
                LastName = _configuration.GetSection("AdminUser:LastName").Value,
                Email = _configuration.GetSection("AdminUser:Email").Value,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                AuthenticatorType = Core.Security.Enums.AuthenticatorType.Email,
                CreatedAt = DateTime.Now
            };
        }
    }
    private void userOperationClaimEntityBuilder(ModelBuilder builder)
    {
        UserOperationClaim[] userOperationClaimSeeds =
        {
            new(1,1,1),new(2,1,2)
        };
        builder.Entity<UserOperationClaim>().HasData(userOperationClaimSeeds);
    }
}
