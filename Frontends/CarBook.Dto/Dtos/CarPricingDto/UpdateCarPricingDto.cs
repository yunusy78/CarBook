namespace CarBook.Dto.Dtos.CarPricingDto;

public class UpdateCarPricingDto
{
    public int CarPricingId { get; set; }
    
    public int CarId { get; set; }
    
    public int PricingId { get; set; }
    
    public decimal Price { get; set; }
}