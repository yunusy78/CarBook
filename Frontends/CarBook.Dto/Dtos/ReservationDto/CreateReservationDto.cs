namespace CarBook.Dto.Dtos.ReservationDto;

public class CreateReservationDto
{
    public int CarId { get; set; }
    public int PickUpLocationId { get; set; }
    public int DropOffLocationId { get; set; }
    public DateOnly PickUpDate { get; set; }
    public DateOnly DropOffDate { get; set; }
    public TimeOnly PickUpTime { get; set; }
    public TimeOnly DropOffTime { get; set; }
    public int TotalDays { get; set; }
    public int TotalPrice { get; set; }
    public int CustomerId { get; set; }
    public string PickUpDescription { get; set; }
    public string DropOffDescription { get; set; }
}