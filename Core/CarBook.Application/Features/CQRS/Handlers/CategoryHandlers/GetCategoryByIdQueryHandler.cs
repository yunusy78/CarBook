using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using CarBook.Application.Features.CQRS.Results.CategoryResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers;

public class GetCategoryByIdQueryHandler
{
    private readonly IRepository<Category> _repository;
    
    public GetCategoryByIdQueryHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }
    
    public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery request)
    {
      var category=  await _repository.GetByIdAsync(request.CategoryId);
        
        var categoryDto = new GetCategoryByIdQueryResult()
        {
            CategoryId = category.CategoryId,
            Name = category.Name
        };
        
        return categoryDto;
    }
}