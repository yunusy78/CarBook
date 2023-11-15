using CarBook.Application.Features.CQRS.Queries.About;
using CarBook.Application.Interfaces;

namespace CarBook.Application.Features.CQRS.Handlers.About;

public class GetAboutByIdQueryHandler
{
    
    private readonly IRepository<Domain.Entities.About> _repository;
    
    public GetAboutByIdQueryHandler(IRepository<Domain.Entities.About> repository)
    {
        _repository = repository;
    }
    
    
    public async Task<Domain.Entities.About> Handle(GetAboutByIdQuery request)
    {
        var about = await _repository.GetByIdAsync(request.AboutId);
        return about;
    }
    
    
    
}