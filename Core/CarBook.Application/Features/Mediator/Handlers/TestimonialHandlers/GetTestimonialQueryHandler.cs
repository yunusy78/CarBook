using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.TestimonialResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers;

public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
{
    private readonly IRepository<Testimonial> _repository;
    
    public GetTestimonialQueryHandler(IRepository<Testimonial> repository)
    {
        _repository = repository;
    }
    
    public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
    {
        var testimonials = await _repository.ListAllAsync();
        var result = testimonials.Select(x => new GetTestimonialQueryResult
        {
            TestimonialId = x.TestimonialId,
            Name = x.Name,
            Description = x.Description,
            ImageUrl = x.ImageUrl,
            Title = x.Title
            
        }).ToList();
        return result;
    }
}