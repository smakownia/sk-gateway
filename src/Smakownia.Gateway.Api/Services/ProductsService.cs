using Smakownia.Gateway.Api.Clients;
using Smakownia.Gateway.Api.Models;

namespace Smakownia.Gateway.Api.Services;

public class ProductsService : IProductsService
{
    private readonly IProductsClient _productsClient;

    public ProductsService(IProductsClient productsClient)
    {
        _productsClient = productsClient;
    }

    public async Task<ProductData> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _productsClient.GetByIdAsync(id, cancellationToken);
    }
}
