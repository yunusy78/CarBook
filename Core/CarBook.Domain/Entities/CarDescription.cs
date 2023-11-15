namespace CarBook.Domain.Entities;

public class CarDescription
{
    public int CarDescriptionId { get; set; }
    
    public string Description { get; set; }
    
    public int CarId { get; set; }
    
    public Car Car { get; set; }
    
}