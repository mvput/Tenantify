using Tenantify.Abstractions;

namespace Tenantify;

internal class TenantResolver<TTenant, TId, TIdentifier>
    (IEnumerable<ITenantStrategy<TTenant,TId, TIdentifier>> strategies,
        IEnumerable<ITenantStore<TTenant,TId,TIdentifier>> stores): ITenantResolver<TTenant, TId, TIdentifier> where TTenant : ITenant<TId, TIdentifier> where TId : IEquatable<TId>, ISpanParsable<TId>
    where TIdentifier : IEquatable<TIdentifier>, ISpanParsable<TIdentifier>
{
    public async Task<TTenant?> Resolve(object context)
    {
        TIdentifier? identifier = default;
        TTenant? tenant = default;
        foreach (var strategy in strategies)
        {
            identifier = await strategy.ResolveIdentifier(context);
            if (identifier is null)
            {
                break;
            }
        }

        if (identifier is null)
        {
            return tenant;
        }

        foreach (var store in stores)
        {
            tenant = await store.GetByIdentifier(identifier);
            if (tenant is not null)
            {
                break;
            }
        }

        return tenant;
    }
}