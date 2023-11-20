using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.AuthorResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers;

public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResult>>
{
    private readonly IRepository<Author> _repository;
    
    public GetAuthorQueryHandler(IRepository<Author> repository)
    {
        _repository = repository;
    }
    
    public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
    {
        var authors = await _repository.ListAllAsync();
        var result = authors.Select(x => new GetAuthorQueryResult
        {
            AuthorId = x.AuthorId,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Email = x.Email,
            
        }).ToList();
        return result;
    }
}