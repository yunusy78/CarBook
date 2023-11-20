using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers;

public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand>
{
    private readonly IRepository<Blog> _repository;
    
    public DeleteBlogCommandHandler(IRepository<Blog> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = await _repository.GetByIdAsync(request.BlogId);
       await _repository.DeleteAsync(blog);
    }
}