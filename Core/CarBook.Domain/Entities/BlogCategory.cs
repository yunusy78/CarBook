namespace CarBook.Domain.Entities;

public class BlogCategory
{
    
    public int BlogCategoryId { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public List<Blog> Blogs { get; set; }
    
}