using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers;


public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
{
    private readonly IRepository<Author> _repository;
    
    public UpdateAuthorCommandHandler(IRepository<Author> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
      var author = await _repository.GetByIdAsync(request.AuthorId);
        author.FirstName = request.FirstName;
        author.LastName = request.LastName;
        author.Email = request.Email;
        author.ImageUrl = request.ImageUrl;
        author.Description = request.Description;
      await _repository.UpdateAsync(author);
    }
}
