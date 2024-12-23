using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Tenantify.Abstractions;

namespace Tenantify.AspNetCore.Middleware;

internal class TenantifyMiddleware<TTenant, TId, TIdentifier>(RequestDelegate next) where TTenant : ITenant<TId, TIdentifier> where TId : IEquatable<TId>, ISpanParsable<TId> where TIdentifier : IEquatable<TIdentifier>, ISpanParsable<TIdentifier>
{
    public async Task Invoke(HttpContext context)
    { 
        var tenantScope = context.RequestServices.GetRequiredService<ITenantScope<TTenant, TId, TIdentifier>>();
        var tenantResolver = context.RequestServices.GetRequiredService<ITenantResolver<TTenant, TId, TIdentifier>>();

        var tenant = await tenantResolver.Resolve(context);
        tenantScope.Resolve(tenant);

        await next(context);
    }
}