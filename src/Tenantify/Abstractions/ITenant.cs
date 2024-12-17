namespace Tenantify.Abstractions;

public interface ITenant<out TId, out TIdentifier> where TId : IEquatable<TId>, ISpanParsable<TId> where TIdentifier : IEquatable<TIdentifier>, ISpanParsable<TIdentifier>
{
    TId Id { get; }
    
    TIdentifier Identifier { get; }
}