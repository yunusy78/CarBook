using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers;

public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand>
{
    private readonly IRepository<Testimonial> _repository;
    
    public CreateTestimonialCommandHandler(IRepository<Testimonial> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
    {
        var testimonial = new Testimonial
        {
            Name = request.Name,
            Description = request.Description,
            ImageUrl = request.ImageUrl,
            
        };
        await _repository.AddAsync(testimonial);
    }
}
