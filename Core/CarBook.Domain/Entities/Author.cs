﻿namespace CarBook.Domain.Entities;

public class Author
{
    
    public int AuthorId { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    
    public List<Blog> Blogs { get; set; }
    
    
}