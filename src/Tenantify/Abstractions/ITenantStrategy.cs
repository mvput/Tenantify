namespace Tenantify.Abstractions;

public interface ITenantStrategy<TTenant, TId, TIdentifier> where TTenant : ITenant<TId, TIdentifier>
    where TId : IEquatable<TId>, ISpanParsable<TId>
    where TIdentifier : IEquatable<TIdentifier>, ISpanParsable<TIdentifier>
{
    Task<TIdentifier?> ResolveIdentifier(object context);
}