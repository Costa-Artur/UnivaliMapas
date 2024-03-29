using Microsoft.EntityFrameworkCore;
using UnivaliMapas.Api.DbContexts;

namespace UnivaliMapas.Api.Extensions;

internal static class StartupHelperExtensions
{
    public static async Task ResetDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        try
        {
            var univaliContext = scope.ServiceProvider.GetService<UnivaliContext>();
            if (univaliContext != null)
            {
                await univaliContext.Database.EnsureDeletedAsync();
                await univaliContext.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred while migrating or seeding the database.");
        }
    }
}