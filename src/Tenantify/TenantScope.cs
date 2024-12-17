using Tenantify.Abstractions;

namespace Tenantify;

internal class TenantScope<TTenant, TId, TIdentifier> : ITenantScope<TTenant, TId, TIdentifier>
    where TTenant : ITenant<TId, TIdentifier>
    where TId : IEquatable<TId>, ISpanParsable<TId>
    where TIdentifier : IEquatable<TIdentifier>, ISpanParsable<TIdentifier>
{
    public TTenant? Tenant { get; private set; }
    public void Resolve(TTenant? tenant)
    {
        Tenant = tenant;
    }
}