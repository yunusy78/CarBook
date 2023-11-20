using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.FooterResults;
using CarBook.Application.Features.Mediator.Results.TestimonialResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.TestimonialQueries;

public class GetTestimonialQuery : IRequest<List<GetTestimonialQueryResult>>
{
    
}