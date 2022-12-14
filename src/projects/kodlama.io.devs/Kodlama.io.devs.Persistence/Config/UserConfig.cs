using Core.Security.Entities;
using Core.Security.Hashing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Kodlama.io.devs.Persistence.Config;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User")
            .HasKey(u => u.Id);

        builder.HasMany(u => u.RefreshTokens);
        builder.HasMany(u => u.UserOperationClaims);
        //builder.HasOne(u => u.GitHub);

        builder.Property(p => p.Id)
            .HasColumnName("Id");

        builder.Property(u => u.FirstName)
            .HasColumnName("FirstName")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(u => u.LastName)
            .HasColumnName("LastName")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(u => u.Email)
            .HasColumnName("Email")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(u => u.PasswordHash)
            .HasColumnName("PasswordHash")
            .IsRequired();
        builder.Property(u => u.PasswordSalt)
            .HasColumnName("PasswordSalt")
            .IsRequired();

        builder.Property(u => u.Status)
            .HasColumnName("Status");

        builder.Property(u => u.AuthenticatorType)
            .HasColumnName("AuthenticatorType");

        builder.Property(p => p.CreatedAt)
            .HasColumnName("CreatedAt");
        builder.Property(p => p.UpdatedAt)
            .HasColumnName("UpdatedAt");
        builder.Property(p => p.DeletedAt)
            .HasColumnName("DeletedAt");

        User user = getUser();

        User[] userEntitySeeds =
        {
            user
        };
        builder.HasData(userEntitySeeds);

        User getUser()
        {
            byte[] passwordHash, passwordSalt;
            string password = configuration().GetSection("AdminUser:Password").Value;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            return new()
            {
                Id = 1,
                FirstName = configuration().GetSection("AdminUser:FirstName").Value,
                LastName = configuration().GetSection("AdminUser:LastName").Value,
                Email = configuration().GetSection("AdminUser:Email").Value,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                AuthenticatorType = Core.Security.Enums.AuthenticatorType.Email,
                CreatedAt = DateTime.Now
            };
        }
        IConfigurationRoot configuration()
        {
            return new ConfigurationManager()
                .AddJsonFile("appsettings.json").Build();
        }
    }
}
