namespace CarBook.Domain.DTOs.CarFeatureDto;

public class GetCarFeatureWithCarDto
{
    
    public int CarFeatureId { get; set; }
    
    public int CarId { get; set; }
    
    public string FeatureName { get; set; }
    
    public string CarModel { get; set; }
    
    public int FeatureId { get; set; }
    
    public bool IsAvailable { get; set; }
}