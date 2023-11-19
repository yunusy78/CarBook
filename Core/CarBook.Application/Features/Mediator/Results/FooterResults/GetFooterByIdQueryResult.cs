namespace CarBook.Application.Features.Mediator.Results.FooterResults;

public class GetFooterByIdQueryResult
{
    public int FooterId { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public string Email { get; set; }
    
    public string Phone { get; set; }
    
    public string Address { get; set; }
}