namespace CarBook.Dto.Dtos.CarDto;

public class CarDto
{
    public CarDto(Dictionary<string, decimal> pricingData)
    {
        PricingData = pricingData;
    }

    public int CarId { get; set; }
    
    public int BrandId { get; set; }
    
    public string BrandName { get; set; }
    
    public string Model { get; set; }
    
    public int LocationId { get; set; }
    
    public int CategoryId { get; set; }
    
    public string CategoryName { get; set; }
    
    public int Year { get; set; }
    
    public string Color { get; set; }
    
    public string ImageUrl { get; set; }
    
    public int Price { get; set; }
    
    public int Mileage { get; set; }
    
    public byte Seats { get; set; }
    
    public byte Luggage { get; set; }
    
    public byte Doors { get; set; }
    
    public bool IsAvailable { get; set; }
    
    public int Transmission { get; set; }
    
    public string Fuel { get; set; }
    
    public Dictionary<string, decimal> PricingData { get; set; }
    
    public List<string> PricingNames { get; set; } 
    public List<decimal> PricingAmounts { get; set; }

    
}