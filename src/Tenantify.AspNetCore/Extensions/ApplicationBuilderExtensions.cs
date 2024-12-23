using Microsoft.AspNetCore.Builder;
using Tenantify.Abstractions;
using Tenantify.AspNetCore.Middleware;

namespace Tenantify.AspNetCore.Extensions;

public  static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseTenantify<TTenant, TId, TIdentifier>(this IApplicationBuilder app) where TTenant : ITenant<TId, TIdentifier> where TId : IEquatable<TId>, ISpanParsable<TId> where TIdentifier : IEquatable<TIdentifier>, ISpanParsable<TIdentifier>
    {
       return app.UseMiddleware<TenantifyMiddleware<TTenant, TId, TIdentifier>>();
    }

    public static IApplicationBuilder UseTenantify(this IApplicationBuilder app) => app.UseTenantify<Tenant, Guid, Guid>();
}