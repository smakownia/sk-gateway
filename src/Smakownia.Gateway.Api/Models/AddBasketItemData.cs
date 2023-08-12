namespace Smakownia.Gateway.Api.Models;

public class AddBasketItemData
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public long Price { get; set; } = new();
    public int Quantity { get; set; }
}
