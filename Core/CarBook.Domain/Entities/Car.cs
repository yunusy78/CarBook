namespace CarBook.Domain.Entities;

public class Car
{
    public int CarId { get; set; }
    
    public int BrandId { get; set; }
    
    public Brand Brand { get; set; }
    
    public string Model { get; set; }
    
    public int LocationId { get; set; }
    
    public Location Location { get; set; }
    
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
    
    public List<CarFeature> CarFeatures { get; set; }
    
    public List<CarDescription> CarDescriptions { get; set; }
    
    public List<CarPricing> CarPricings { get; set; }
    
    
    
    
}