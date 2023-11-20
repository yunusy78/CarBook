using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TestimonialCommands;

public class UpdateTestimonialCommand : IRequest
{
    
    public int TestimonialId { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string ImageUrl { get; set; }
}
