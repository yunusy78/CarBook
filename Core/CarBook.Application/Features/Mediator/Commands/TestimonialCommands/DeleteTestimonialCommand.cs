using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TestimonialCommands;

public class DeleteTestimonialCommand : IRequest
{
    public DeleteTestimonialCommand(int id)
    {
        TestimonialId = id;
    }

    public int TestimonialId { get; set; }
    
    
    
    
}