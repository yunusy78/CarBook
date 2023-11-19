using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.LocationCommands;

public class DeleteLocationCommand : IRequest
{
    public DeleteLocationCommand(int id)
    {
        LocationId = id;
    }

    public int LocationId { get; set; }
    
    
    
    
}