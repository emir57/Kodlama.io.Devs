using Microsoft.Extensions.Configuration;

namespace Core.Persistence.Extensions;

public static class ContextExtensions
{
    public static string GetConnectionString(this IConfigurationBuilder configurationBuilder, string connectionStringName)
    {
        IConfigurationRoot configurationRoot = configurationBuilder.Build();

        return configurationRoot.GetConnectionString(connectionStringName);
    }
}
