namespace CarBook.Dto.Dtos.CommentDto;

public class CommentDto
{
    
    public int CommentId { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; }
    
    public string Message { get; set; } = null!;
    
    public int BlogId { get; set; }
    
}