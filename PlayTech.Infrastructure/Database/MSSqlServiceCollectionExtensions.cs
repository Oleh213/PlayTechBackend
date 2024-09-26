using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using PlayTech.Abstractions.AppSettings;

namespace PlayTech.Infrastructure.Database;

public static class MSSqlServiceCollectionExtensions
{
    public static void AddMSSqlInfrastructure(this IServiceCollection services, AppSettings appSettings)
    {
        
        services.AddTransient<IDbConnection>((sp) =>
            new SqlConnection(appSettings.ConnectionString));
    }
}