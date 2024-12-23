using Microsoft.Extensions.DependencyInjection;
using Tenantify.Abstractions;
using Tenantify.AspNetCore.Strategies;

namespace Tenantify.AspNetCore.Extensions;

public static class TenantBuilderExtensions
{

    public static TenantBuilder<TTenant, TId, TIdentifier> AddHeaderStrategy<TTenant, TId, TIdentifier>(
        this TenantBuilder<TTenant, TId, TIdentifier> builder, string headerKey = "X-Tenant-Id") where TTenant : ITenant<TId, TIdentifier> where TId : IEquatable<TId>, ISpanParsable<TId> where TIdentifier : IEquatable<TIdentifier>, ISpanParsable<TIdentifier>
    {
        builder.Services.Configure<HeaderOptions>(opt => opt.HeaderKey = headerKey);
        return builder.AddStrategy<HeaderStrategy<TTenant, TId, TIdentifier>>(ServiceLifetime.Singleton);
    }
 
}