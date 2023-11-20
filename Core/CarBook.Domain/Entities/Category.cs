namespace CarBook.Domain.Entities;

public class Category
{
    public int CategoryId { get; set; }
    
    public string Name { get; set; }
    
    
    public List<Car> Cars { get; set; }
}