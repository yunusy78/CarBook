using CarBook.Domain.Entities;

namespace CarBook.Domain.Service;

public class StripeService
{
    public string SecretKey { get; set; }
    public string PublishableKey { get; set; }
    public string ApprovedUrl { get; set; }
    public string CancelUrl { get; set; }
    public Order Order { get; set; } = null!;
}