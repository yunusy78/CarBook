using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers;

public class DeleteContactCommandHandler
{
    private readonly IRepository<Contact> _repository;
    
    
    public DeleteContactCommandHandler(IRepository<Contact> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(DeleteContactCommand request)
    {
        var contact = await _repository.GetByIdAsync(request.ContactId);
        
        await _repository.DeleteAsync(contact);
    }
}