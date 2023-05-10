using Microsoft.EntityFrameworkCore;
using Persistence;

namespace WebAPI.Extensions;

public static class WebApplicationExtensions
{
    public static void Migrate(this WebApplication application)
    {
        var serviceScope = application.Services.GetService<IServiceScopeFactory>()?.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
        context.Database.MigrateAsync();
    }
}