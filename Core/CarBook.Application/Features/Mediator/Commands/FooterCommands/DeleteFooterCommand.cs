using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.FooterCommands;

public class DeleteFooterCommand : IRequest
{
    public DeleteFooterCommand(int id)
    {
        FooterId = id;
    }

    public int FooterId { get; set; }
    
    
    
    
}