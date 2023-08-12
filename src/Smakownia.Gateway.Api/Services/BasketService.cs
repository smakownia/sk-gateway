using Smakownia.Gateway.Api.Clients;
using Smakownia.Gateway.Api.Exceptions;
using Smakownia.Gateway.Api.Models;

namespace Smakownia.Gateway.Api.Services;

public class BasketService : IBasketService
{
    private const string _basketIdCookieName = "basketId";

    private readonly HttpContext _httpContext;
    private readonly IBasketClient _basketClient;

    public BasketService(IHttpContextAccessor httpContextAccessor, IBasketClient basketClient)
    {
        _httpContext = httpContextAccessor.HttpContext ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        _basketClient = basketClient;
    }

    public async Task<BasketData> AddItem(AddBasketItemData data, CancellationToken cancellationToken = default)
    {
        return await _basketClient.AddItem(data, GetBasketId(), cancellationToken);
    }

    private string GetBasketId()
    {
        if (!_httpContext.Request.Cookies.TryGetValue(_basketIdCookieName, out var basketId))
        {
            throw new BadRequestException();
        }

        return basketId!;
    }
}
