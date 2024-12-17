using Microsoft.Extensions.DependencyInjection;
using Tenantify.Abstractions;
using Tenantify.Extensions;

namespace Tenantify;

public class TenantBuilder<TTenant, TId, TIdentifier>(IServiceCollection services)where TTenant : ITenant<TId, TIdentifier> where TId : IEquatable<TId>, ISpanParsable<TId>
    where TIdentifier : IEquatable<TIdentifier>, ISpanParsable<TIdentifier>
{
    public TenantBuilder<TTenant, TId, TIdentifier> AddStore<TStore>(ServiceLifetime lifetime)
        where TStore : class, ITenantStore<TTenant, TId, TIdentifier> 
    {
        
        services.Add<ITenantStore<TTenant, TId, TIdentifier>, TStore > (lifetime);
        return this;
    }
    
    public TenantBuilder<TTenant, TId, TIdentifier> AddStrategy<TStrategy>(ServiceLifetime lifetime)
        where TStrategy : class, ITenantStrategy<TTenant, TId, TIdentifier> 
    {
        services.Add<ITenantStrategy<TTenant, TId, TIdentifier>, TStrategy > (lifetime);
        return this;
    }
}