namespace CarBook.Domain.Entities;

public class Location
{
    public int LocationId { get; set; }
    
    public string Name { get; set; }
    
    
    public List<Car> Cars { get; set; }
    
    public List<ReservationCar> PickUpRentACars { get; set; }
    
    public List<ReservationCar> DropOffRentACars { get; set; }
    
   
  
    
}