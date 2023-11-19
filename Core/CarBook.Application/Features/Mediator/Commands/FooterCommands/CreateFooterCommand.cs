using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.FooterCommands;

public class CreateFooterCommand : IRequest
{
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public string Email { get; set; }
    
    public string Phone { get; set; }
    
    public string Address { get; set; }

}