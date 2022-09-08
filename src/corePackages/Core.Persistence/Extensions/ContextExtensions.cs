using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;

namespace Core.Persistence.Extensions;

public static class ContextExtensions
{
    public static string GetConnectionString(this IConfigurationBuilder configurationBuilder, string connectionStringName)
    {
        IConfigurationRoot configurationRoot = configurationBuilder.Build();

        return configurationRoot.GetConnectionString(connectionStringName);
    }

    public static void SetStateDate(this IEnumerable<EntityEntry<Entity>> entityEntries)
    {
        foreach (EntityEntry<Entity> entry in entityEntries)
        {
            var _ = entry.State switch
            {
                EntityState.Added => entry.Entity.CreatedAt = DateTime.Now,
                EntityState.Modified => entry.Entity.UpdatedAt = DateTime.Now,
                _ => DateTime.Now
            };
        }
    }
}
