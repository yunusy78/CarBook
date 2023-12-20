
namespace CarBook.Dto.Dtos.Stripe;

public class StripeServiceDto
{
    public string SecretKey { get; set; }
    public string PublishableKey { get; set; }
    public string ApprovedUrl { get; set; }
    public string CancelUrl { get; set; }
}