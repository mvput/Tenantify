namespace Tenantify.Abstractions;

public interface ITenantStore<TTenant, TId, in TIdentifier> where TTenant : ITenant<TId, TIdentifier>  where TId : IEquatable<TId>, ISpanParsable<TId>
    where TIdentifier : IEquatable<TIdentifier>, ISpanParsable<TIdentifier>
{
    Task<TTenant?> GetByIdentifier(TIdentifier identifier);
}