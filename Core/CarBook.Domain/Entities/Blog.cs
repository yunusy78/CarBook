namespace CarBook.Domain.Entities;

public class Blog
{
    public int BlogId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    public string ImageUrl { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
    public string CoverImage { get; set; }
    public int CategoryId { get; set; }
    public BlogCategory Category { get; set; }
    
    public List<TagCloud> TagClouds { get; set; }
    
    public List<Comment> Comments { get; set; }
    
}