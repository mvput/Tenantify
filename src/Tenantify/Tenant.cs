using Tenantify.Abstractions;

namespace Tenantify;

public class Tenant : ITenant<Guid, Guid>
{
    public Guid Id { get; init;  }
    
    public Guid Identifier { get; init; }
}