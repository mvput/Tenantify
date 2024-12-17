namespace Tenantify.Abstractions;

public interface ITenantResolver<TTenant, TId, TIdentifier> where TTenant : ITenant<TId, TIdentifier>  where TId : IEquatable<TId>, ISpanParsable<TId>
    where TIdentifier : IEquatable<TIdentifier>, ISpanParsable<TIdentifier>
{
    Task<TTenant?> Resolve(object context);
}