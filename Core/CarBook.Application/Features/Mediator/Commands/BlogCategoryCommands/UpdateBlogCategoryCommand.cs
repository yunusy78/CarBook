using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BlogCategoryCommands;

public class UpdateBlogCategoryCommand : IRequest
{
    
    public int BlogCategoryId { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
}
