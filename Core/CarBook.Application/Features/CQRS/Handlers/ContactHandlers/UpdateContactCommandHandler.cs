using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers;

public class UpdateContactCommandHandler
{
    private readonly IRepository<Contact> _repository;
    
    public UpdateContactCommandHandler(IRepository<Contact> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(UpdateContactCommand request)
    {
        var contact = await _repository.GetByIdAsync(request.ContactId);
        contact.Name = request.Name;
        contact.CreatedAt = request.CreatedAt;
        contact.Email= request.Email;
        contact.Subject= request.Subject;
        contact.Message= request.Message;
        await _repository.UpdateAsync(contact);
    }
}