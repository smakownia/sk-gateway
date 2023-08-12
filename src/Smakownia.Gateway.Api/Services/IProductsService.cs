using Smakownia.Gateway.Api.Models;

namespace Smakownia.Gateway.Api.Services;

public interface IProductsService
{
    Task<ProductData> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
