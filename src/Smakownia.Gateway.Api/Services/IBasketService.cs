using Smakownia.Gateway.Api.Models;

namespace Smakownia.Gateway.Api.Services;

public interface IBasketService
{
    Task<BasketData> AddItem(AddBasketItemData data, CancellationToken cancellationToken = default);
}
