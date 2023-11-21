using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TestimonialCommands;

public class CreateTestimonialCommand : IRequest
{
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string ImageUrl { get; set; }
    
    public string Title { get; set; }
    
    

}