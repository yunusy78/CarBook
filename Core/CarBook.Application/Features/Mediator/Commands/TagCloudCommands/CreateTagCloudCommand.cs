using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TagCloudCommands;

public class CreateTagCloudCommand : IRequest
{
    
    public string Tag { get; set; }
    
    public int BlogId { get; set; }
}