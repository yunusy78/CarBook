using CarBook.Application.Features.Mediator.Results.BlogResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogQueries;

public class GetLast3BlogWithCategoryAndAuthorQuery : IRequest<List<GetLast3BlogsWithCategoryAndAuthorQueryResult>>
{
    
}