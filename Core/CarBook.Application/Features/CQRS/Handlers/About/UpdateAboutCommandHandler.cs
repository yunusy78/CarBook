using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Interfaces;

namespace CarBook.Application.Features.CQRS.Handlers.About;

public class UpdateAboutCommandHandler
{
            private readonly IRepository<Domain.Entities.About> _repository;

            public UpdateAboutCommandHandler(IRepository<Domain.Entities.About> repository)
            {
                _repository = repository;
            }
            
            
            public async Task Handle(UpdateAboutCommands request)
            {
                var about = await _repository.GetByIdAsync(request.AboutId);
                about.Title = request.Title;
                about.Description = request.Description;
                about.ImageUrl = request.ImageUrl;
                await _repository.UpdateAsync(about);
            }
            
            
            
}