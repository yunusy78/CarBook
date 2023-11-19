using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.FooterCommands;

public class UpdateFooterCommand : IRequest
{
    
    public int FooterId { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public string Email { get; set; }
    
    public string Phone { get; set; }
    
    public string Address { get; set; }
}
