namespace CarBook.Domain.DTOs;

public class GetReservationDto
{
    public int ReservationCarId { get; set; }
    public int CarId { get; set; }
    public int PickUpLocationId { get; set; }
    public string PickUpLocationName { get; set; }
    public int DropOffLocationId { get; set; }
    public string DropOffLocationName { get; set; }
    public DateOnly PickUpDate { get; set; }
    public DateOnly DropOffDate { get; set; }
    public TimeOnly PickUpTime { get; set; }
    public TimeOnly DropOffTime { get; set; }
    public int TotalDays { get; set; }
    public int TotalPrice { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string PickUpDescription { get; set; }
    public string DropOffDescription { get; set; }
    public string CarBrand { get; set; }
    public string CarModel { get; set; }
    public string CarLocation { get; set; }
    public string CarLocationName { get; set; }
    public string CarPricing { get; set; }
    public string CarPricingType { get; set; }
    public string CarImageUrl { get; set; }
}