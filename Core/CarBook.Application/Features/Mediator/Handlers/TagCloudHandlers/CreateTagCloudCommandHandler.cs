using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers;

public class CreateTagCloudCommandHandler : IRequestHandler<CreateTagCloudCommand>
{
    private readonly IRepository<TagCloud> _repository;
    
    public CreateTagCloudCommandHandler(IRepository<TagCloud> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(CreateTagCloudCommand request, CancellationToken cancellationToken)
    {
        var tagCloud = new TagCloud
        {
            Tag = request.Tag,
            BlogId = request.BlogId
            
        };
        await _repository.AddAsync(tagCloud);
    }
}
