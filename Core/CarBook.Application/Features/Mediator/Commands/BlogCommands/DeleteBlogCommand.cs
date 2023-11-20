using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BlogCommands;

public class DeleteBlogCommand : IRequest
{
    public DeleteBlogCommand(int id)
    {
        BlogId = id;
    }

    public int BlogId { get; set; }
    
    
    
    
}