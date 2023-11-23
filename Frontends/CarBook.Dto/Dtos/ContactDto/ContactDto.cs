namespace CarBook.Dto.Dtos.ContactDto;

public class ContactDto
{
    
    public int ContactId { get; set; }
    
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public string Subject { get; set; }
    
    public string Message { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
}