﻿namespace CarBook.Dto.Dtos.BlogDto;

public class BlogDto
{
    public int BlogId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    public string ImageUrl { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
    public int AuthorId { get; set; }
    public string AuthorName { get; set; }
    
    public string AuthorDescription { get; set; }
    
    public string AuthorImageUrl { get; set; }
    public string CoverImage { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}