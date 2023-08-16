using Smakownia.Gateway.Api.Models;

namespace Smakownia.Gateway.Api.Clients;

public interface IBasketClient
{
    Task<BasketData> AddItem(AddBasketItemData data,
                             string basketId,
                             string? authorization,
                             CancellationToken cancellationToken = default);
}
