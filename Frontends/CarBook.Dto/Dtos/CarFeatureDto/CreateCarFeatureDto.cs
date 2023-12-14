namespace CarBook.Dto.Dtos.CarFeatureDto;

public class CreateCarFeatureDto
{
    
    public int CarId { get; set; }
    
    public int FeatureId { get; set; }
    
    public bool IsAvailable { get; set; }
}