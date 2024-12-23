using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Tenantify.Abstractions;

namespace Tenantify.AspNetCore.Strategies;

public class HeaderStrategy<TTenant, TId, TIdentifier>(IOptions<HeaderOptions> options) : ITenantStrategy<TTenant, TId, TIdentifier> where TTenant : ITenant<TId, TIdentifier> where TId : IEquatable<TId>, ISpanParsable<TId> where TIdentifier : IEquatable<TIdentifier>, ISpanParsable<TIdentifier>
{
    public Task<TIdentifier?> ResolveIdentifier(object context)
    {
        if (context is not HttpContext httpContext)
        {
            return Task.FromResult<TIdentifier?>(default);
        }

        if (!httpContext.Request.Headers.TryGetValue(options.Value.HeaderKey, out var values) || values.Count == 0)
        {
            return Task.FromResult<TIdentifier?>(default);
        }

        return Task.FromResult(TIdentifier.TryParse(values[0], CultureInfo.InvariantCulture, out var result)
            ? result
            : default);
    }
}