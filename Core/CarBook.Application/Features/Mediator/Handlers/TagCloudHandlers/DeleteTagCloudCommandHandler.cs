using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers;

public class DeleteTagCloudCommandHandler : IRequestHandler<DeleteTagCloudCommand>
{
    private readonly IRepository<TagCloud> _repository;
    
    public DeleteTagCloudCommandHandler(IRepository<TagCloud> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(DeleteTagCloudCommand request, CancellationToken cancellationToken)
    {
        var tagCloud = await _repository.GetByIdAsync(request.TagCloudId);
       await _repository.DeleteAsync(tagCloud);
    }
}