using Smakownia.Gateway.Api.Exceptions;
using Smakownia.Gateway.Api.Models;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Smakownia.Gateway.Api.Clients;

public class BasketClient : IBasketClient
{
    private readonly Uri _baseUrl;

    public BasketClient(IConfiguration configuration)
    {
        _baseUrl = new(configuration["Urls:Basket"]!);
    }

    public async Task<BasketData> AddItem(AddBasketItemData data,
                                          string basketId,
                                          string? authorization,
                                          CancellationToken cancellationToken = default)
    {
        var json = JsonSerializer.Serialize(data);
        var cookieContainer = new CookieContainer();

        using var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
        using var content = new StringContent(json, Encoding.UTF8, "application/json");
        using var client = new HttpClient(handler) { BaseAddress = _baseUrl};

        cookieContainer.Add(_baseUrl, new Cookie("basketId", basketId));
        cookieContainer.Add(_baseUrl, new Cookie("Authorization", authorization));

        using var response = await client.PostAsync("/api/v1/basket/items", content, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new BadRequestException();
        }

        var basket = await response.Content.ReadFromJsonAsync<BasketData>(new JsonSerializerOptions { PropertyNameCaseInsensitive = true },
                                                                          cancellationToken);

        if (basket is null)
        {
            throw new BadRequestException();
        }

        return basket;
    }
}
