using Microsoft.Extensions.DependencyInjection;
using Tenantify.Abstractions;

namespace Tenantify.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTenantify<TTenant, TId, TIdentifier>(this IServiceCollection services) where TTenant : ITenant<TId, TIdentifier>  where TId : IEquatable<TId>, ISpanParsable<TId>
        where TIdentifier : IEquatable<TIdentifier>, ISpanParsable<TIdentifier>
    {
        services.AddScoped<ITenantResolver<TTenant, TId,TIdentifier>, TenantResolver<TTenant, TId, TIdentifier>>();
        services.AddScoped<ITenantScope<TTenant, TId, TIdentifier>, TenantScope<TTenant, TId, TIdentifier>>();

        return services;
    }

    public static IServiceCollection Add<TService, TImplementation>(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped) where TService : class where TImplementation : class, TService
    {
        switch (lifetime)
        {
            case ServiceLifetime.Singleton:
                services.AddSingleton<TService, TImplementation>();
                break;
            case ServiceLifetime.Transient:
                services.AddTransient<TService, TImplementation>();
                break;
            case ServiceLifetime.Scoped:
            default:
                services.AddScoped<TService, TImplementation>();
                break;
        }

        return services;
    }
}