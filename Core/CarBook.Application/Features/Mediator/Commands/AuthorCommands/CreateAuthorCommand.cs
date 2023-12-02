using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.AuthorCommands;

public class CreateAuthorCommand : IRequest
{
    
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string ImageUrl { get; set; }
    
    public string Description { get; set; }
    
    public string Email { get; set; }
    
    

}