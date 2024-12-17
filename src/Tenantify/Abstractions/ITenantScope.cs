namespace Tenantify.Abstractions;

public interface ITenantScope<TTenant, out TId, out TIdentifier> where TTenant : ITenant<TId, TIdentifier> where TId : IEquatable<TId>, ISpanParsable<TId>
    where TIdentifier : IEquatable<TIdentifier>, ISpanParsable<TIdentifier>
{
    TTenant? Tenant { get; }
    
    void Resolve(TTenant? tenant);
}