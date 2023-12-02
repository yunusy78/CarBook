namespace CarBook.Application.Features.Mediator.Results.AuthorResults;

public class GetAuthorQueryResult
{
    
    public int AuthorId { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string ImageUrl { get; set; }
    
    public string Description { get; set; }
    
    public string Email { get; set; }
}