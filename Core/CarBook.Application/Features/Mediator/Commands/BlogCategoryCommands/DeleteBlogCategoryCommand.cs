using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BlogCategoryCommands;

public class DeleteBlogCategoryCommand : IRequest
{
    public DeleteBlogCategoryCommand(int id)
    {
        BlogCategoryId = id;
    }

    public int BlogCategoryId { get; set; }
    
    
    
    
}