using Microsoft.AspNetCore.Mvc;
using Smakownia.Gateway.Api.Models;
using Smakownia.Gateway.Api.Requests;
using Smakownia.Gateway.Api.Services;

namespace Smakownia.Gateway.Api.Controllers;

[ApiController]
[Route("api/v1/basket")]
public class BasketController : ControllerBase
{
    private readonly IProductsService _productsService;
    private readonly IBasketService _basketService;

    public BasketController(IProductsService productsService, IBasketService basketService)
    {
        _productsService = productsService;
        _basketService = basketService;
    }

    [HttpPost("items")]
    public async Task<ActionResult<BasketData>> AddItem([FromBody] AddBasketItemRequest request,
                                                        CancellationToken cancellationToken)
    {
        var product = await _productsService.GetByIdAsync(request.Id, cancellationToken);

        var addBasketItemData = new AddBasketItemData()
        {
            Id = product.Id,
            ImageUrl = product.ImageUrl,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price.Raw,
            Quantity = request.Quantity
        }; 

        var basket = await _basketService.AddItem(addBasketItemData, cancellationToken);

        return Ok(basket);
    }
}
