using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.ServiceCommands;

public class DeleteServiceCommand : IRequest
{
    public DeleteServiceCommand(int id)
    {
        ServiceId = id;
    }

    public int ServiceId { get; set; }
    
    
    
    
}