namespace CarBook.Application.Features.CQRS.Commands.CategoryCommands;

public class CreateContactCommand
{
    
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public string Subject { get; set; }
    
    public string Message { get; set; }
    
    public DateTime CreatedAt { get; set; }
}