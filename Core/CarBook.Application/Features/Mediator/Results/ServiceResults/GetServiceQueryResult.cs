namespace CarBook.Application.Features.Mediator.Results.ServiceResults;

public class GetServiceQueryResult
{
    public int ServiceId { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    
    public string ImageUrl { get; set; }
}