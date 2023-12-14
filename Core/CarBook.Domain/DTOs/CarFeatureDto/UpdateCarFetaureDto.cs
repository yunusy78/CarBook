namespace CarBook.Domain.DTOs.CarFeatureDto;

public class UpdateCarFetaureDto
{
    
    public int CarFeatureId { get; set; }
    
    public int CarId { get; set; }
    
    public int FeatureId { get; set; }
    
    public bool IsAvailable { get; set; }
}