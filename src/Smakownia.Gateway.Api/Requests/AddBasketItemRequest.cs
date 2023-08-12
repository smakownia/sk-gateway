using System.ComponentModel.DataAnnotations;

namespace Smakownia.Gateway.Api.Requests;

public class AddBasketItemRequest
{
    public Guid Id { get; set; }

    [Required]
    [Range(1, 999)]
    public int Quantity { get; set; }
}
