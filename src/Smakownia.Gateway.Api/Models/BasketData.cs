namespace Smakownia.Gateway.Api.Models;

public class BasketData
{
    public Guid Id { get; set; }
    public IEnumerable<BasketItemData> Items { get; set; } = new List<BasketItemData>();
    public PriceData TotalPrice { get; set; } = new();
    public int TotalItems { get; set; }
}
