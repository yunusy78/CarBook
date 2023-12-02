using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
{
    private readonly IRepository<Author> _repository;
    
    public CreateAuthorCommandHandler(IRepository<Author> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = new Author
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            ImageUrl = request.ImageUrl,
            Description = request.Description,
            Email = request.Email,
           
            
        };
        await _repository.AddAsync(author);
    }
}
