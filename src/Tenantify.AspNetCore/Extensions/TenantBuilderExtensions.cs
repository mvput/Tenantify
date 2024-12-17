using Microsoft.Extensions.DependencyInjection;
using Tenantify.Abstractions;
using Tenantify.AspNetCore.Strategies;

namespace Tenantify.AspNetCore.Extensions;

public static class TenantBuilderExtensions
{
    public static TenantBuilder<TTenant, TId, TIdentifier> AddHeaderStrategy<TTenant, TId, TIdentifier>(
        this TenantBuilder<TTenant, TId, TIdentifier> builder) where TTenant : ITenant<TId, TIdentifier> where TId : IEquatable<TId>, ISpanParsable<TId> where TIdentifier : IEquatable<TIdentifier>, ISpanParsable<TIdentifier>
    {
        return builder.AddHeaderStrategy("X-Tenant-Id");
    }
    
    public static TenantBuilder<TTenant, TId, TIdentifier> AddHeaderStrategy<TTenant, TId, TIdentifier>(
        this TenantBuilder<TTenant, TId, TIdentifier> builder, string headerKey) where TTenant : ITenant<TId, TIdentifier> where TId : IEquatable<TId>, ISpanParsable<TId> where TIdentifier : IEquatable<TIdentifier>, ISpanParsable<TIdentifier>
    {
        return builder.AddStrategy<HeaderStrategy<TTenant, TId, TIdentifier>>(ServiceLifetime.Singleton);
    }
}