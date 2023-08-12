using Smakownia.Gateway.Api.Exceptions;
using Smakownia.Gateway.Api.Models;
using System.Text.Json;

namespace Smakownia.Gateway.Api.Clients;

public class ProductsClient : IProductsClient
{
    private readonly Uri _baseUrl;

    public ProductsClient(IConfiguration configuration)
    {
        _baseUrl = new(configuration["Urls:Products"]!);
    }

    public async Task<ProductData> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        using var client = new HttpClient() { BaseAddress = _baseUrl };

        using var response = await client.GetAsync($"/api/v1/products/{id}", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new ProductNotFoundException(id);
        }

        var product = await response.Content.ReadFromJsonAsync<ProductData>(new JsonSerializerOptions { PropertyNameCaseInsensitive = true },
                                                                            cancellationToken);

        if (product is null)
        {
            throw new ProductNotFoundException(id);
        }

        return product;
    }
}
