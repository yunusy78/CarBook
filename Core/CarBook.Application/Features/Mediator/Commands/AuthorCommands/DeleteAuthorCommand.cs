using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.AuthorCommands;

public class DeleteAuthorCommand : IRequest
{
    public DeleteAuthorCommand(int id)
    {
        AuthorId = id;
    }

    public int AuthorId { get; set; }
    
    
    
    
}