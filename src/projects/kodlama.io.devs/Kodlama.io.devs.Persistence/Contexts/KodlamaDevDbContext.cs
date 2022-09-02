using Core.Persistence.Extensions;
using Kodlama.io.devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kodlama.io.devs.Persistence.Contexts
{
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            programmingLanguageEntityBuilder(modelBuilder);
        }

        private void programmingLanguageEntityBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(p =>
            {
                p.ToTable("ProgrammingLanguages").HasKey(p => p.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.Name).HasColumnName("Name");
            });

            ProgrammingLanguage[] programmingLanguageEntitySeeds =
            {
                new(1,"C#")
            };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);
        }
    }
}
