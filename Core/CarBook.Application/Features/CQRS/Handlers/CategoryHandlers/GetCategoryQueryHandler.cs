using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Features.CQRS.Results.CategoryResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers;

public class GetCategoryQueryHandler
{
    private readonly IRepository<Category> _repository;
    
    public GetCategoryQueryHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }
    
    public async Task<List<GetCategoryQueryResult>> Handle()
    {
        var categories = await _repository.ListAllAsync();
        
        var categoriesResults = categories.Select(banner => new GetCategoryQueryResult()
        {
            CategoryId = banner.CategoryId,
            Name = banner.Name
        }).ToList();
        
        return categoriesResults;
    }
    
}