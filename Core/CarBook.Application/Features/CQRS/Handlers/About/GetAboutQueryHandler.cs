using CarBook.Application.Features.CQRS.Results.About;
using CarBook.Application.Interfaces;

namespace CarBook.Application.Features.CQRS.Handlers.About;

public class GetAboutQueryHandler
{
    private readonly IRepository<Domain.Entities.About> _aboutRepository;
    
    public GetAboutQueryHandler(IRepository<Domain.Entities.About> aboutRepository)
    {
        _aboutRepository = aboutRepository;
    }
    
    public async Task<List<GetAboutQueryResult>> Handle()
    {
        var abouts = await _aboutRepository.ListAllAsync();
        return abouts.Select(about => new GetAboutQueryResult
        {
            AboutId = about.AboutId,
            Title = about.Title,
            Description = about.Description,
            ImageUrl = about.ImageUrl
        }).ToList();
    }
    
    
}