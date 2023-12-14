namespace CarBook.Dto.Dtos.CarFeatureDto;

public class UpdateCarFeatureDto
{
    
    public int CarFeatureId { get; set; }
    
    public int CarId { get; set; }
    
    public int FeatureId { get; set; }
    
    public bool IsAvailable { get; set; }
}