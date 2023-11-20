using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers;


public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
{
    private readonly IRepository<Testimonial> _repository;
    
    public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
    {
      var testimonial = await _repository.GetByIdAsync(request.TestimonialId);
        testimonial.Name = request.Name;
      testimonial.Description = request.Description;
        testimonial.ImageUrl = request.ImageUrl;
      await _repository.UpdateAsync(testimonial);
    }
}
