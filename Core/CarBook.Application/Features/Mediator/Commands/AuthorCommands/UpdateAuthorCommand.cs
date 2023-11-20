using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.AuthorCommands;

public class UpdateAuthorCommand : IRequest
{
    
    public int AuthorId { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
}
