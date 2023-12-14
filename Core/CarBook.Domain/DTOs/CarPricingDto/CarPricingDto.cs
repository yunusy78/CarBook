namespace CarBook.Domain.DTOs.CarPricingDto;

public class CarPricingDto
{
    public int CarPricingId { get; set; }
    
    public int CarId { get; set; }
    
    public string CarModel { get; set; }
    
    public int PricingId { get; set; }
    
    public decimal Price { get; set; }
    
    public string PricingName { get; set; }
}