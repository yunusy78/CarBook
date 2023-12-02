using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TagCloudCommands;

public class UpdateTagCloudCommand : IRequest
{
    
    public int TagCloudId { get; set; }
    
    public string Tag { get; set; }
    
    public int BlogId { get; set; }
    
}
