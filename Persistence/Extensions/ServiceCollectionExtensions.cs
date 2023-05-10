using Application.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccess(
        this IServiceCollection collection,
        Action<DbContextOptionsBuilder> configuration)
    {
        collection.AddDbContext<DatabaseContext>(configuration);
        collection.AddScoped<IDatabaseContext>(x => x.GetRequiredService<DatabaseContext>());
        return collection;
    }
}