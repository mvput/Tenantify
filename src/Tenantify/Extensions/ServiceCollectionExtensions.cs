using Microsoft.Extensions.DependencyInjection;
using Tenantify.Abstractions;

namespace Tenantify.Extensions;

public static class ServiceCollectionExtensions
{
    public static TenantBuilder<TTenant, TId, TIdentifier> AddTenantify<TTenant, TId, TIdentifier>(this IServiceCollection services) where TTenant : ITenant<TId, TIdentifier>  where TId : IEquatable<TId>, ISpanParsable<TId>
        where TIdentifier : IEquatable<TIdentifier>, ISpanParsable<TIdentifier>
    {
        services.AddScoped<ITenantResolver<TTenant, TId,TIdentifier>, TenantResolver<TTenant, TId, TIdentifier>>();
        services.AddScoped<ITenantScope<TTenant, TId, TIdentifier>, TenantScope<TTenant, TId, TIdentifier>>();

        return new TenantBuilder<TTenant, TId, TIdentifier>(services);
    }
    
    public static TenantBuilder<Tenant, Guid, Guid> AddTenantify(this IServiceCollection services) 
    {
        services.AddScoped<ITenantResolver<Tenant, Guid, Guid>, TenantResolver<Tenant, Guid, Guid>>();
        services.AddScoped<ITenantScope<Tenant, Guid, Guid>, TenantScope<Tenant, Guid, Guid>>();

        return new TenantBuilder<Tenant, Guid, Guid>(services);
    }

    internal static IServiceCollection Add<TService, TImplementation>(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped) where TService : class where TImplementation : class, TService
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