using Smakownia.Gateway.Api.Models;

namespace Smakownia.Gateway.Api.Clients;

public interface IProductsClient
{
    Task<ProductData> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
