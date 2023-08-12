namespace Smakownia.Gateway.Api.Models;

public class ProductData
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public PriceData Price { get; set; } = new();
}
