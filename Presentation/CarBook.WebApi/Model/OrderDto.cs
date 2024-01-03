namespace CarBook.WebApi.Model;

public class OrderDto
{
    public int Id { get; set; }
    
    public string?  UserId  { get; set; }
    
    public string PaymentStatus { get; set; }=string.Empty;
    
    public string PaymentType { get; set; }=string.Empty;
    
    public DateTime? PaymentDate { get; set; }
    
    public string SessionId { get; set; }=string.Empty;
    
    public string PaymentIntentId { get; set; }=string.Empty;
    
    public int PersonCount { get; set; }
    
    public DateTime ReservationDate { get; set; }
    
    public int CarId { get; set; }
    
    public string CarModel { get; set; } = string.Empty;
    
    public string? Status { get; set; }
    
    public double TotalPrice { get; set; }
}