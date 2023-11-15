namespace CarBook.Application.Features.CQRS.Results.About;

public class GetAboutQueryResult
{
    
    public int AboutId { get; set; }
    
    public string Title { get; set; }
    
    
    public string Description { get; set; }
    
    public string ImageUrl { get; set; }
    
}