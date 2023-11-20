using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BlogCategoryCommands;

public class CreateBlogCategoryCommand : IRequest
{
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    
    

}