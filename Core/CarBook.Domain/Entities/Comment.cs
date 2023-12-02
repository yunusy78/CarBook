namespace CarBook.Domain.Entities;

public class Comment
{
    public int CommentId { get; set; }
    public string Name { get; set; }
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Description { get; set; }
    public int BlogId { get; set; }
    public Blog Blog { get; set; }
    
}