namespace Smakownia.Gateway.Api.Models;

public class BasketItemData
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public PriceData Price { get; set; } = new();
    public int Quantity { get; set; }
    public PriceData TotalPrice { get; set; } = new();
}
