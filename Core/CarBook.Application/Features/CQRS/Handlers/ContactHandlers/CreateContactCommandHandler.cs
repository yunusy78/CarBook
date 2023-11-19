using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers;

public class CreateContactCommandHandler
{
    private readonly IRepository<Contact> _repository;
    
    public CreateContactCommandHandler(IRepository<Contact> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(CreateContactCommand request)
    {
        var contact = new Contact
        {
            Name = request.Name,
            CreatedAt = DateTime.Now,
            Email = request.Email,
            Subject = request.Subject,
            Message = request.Message
            
        };
        
        await _repository.AddAsync(contact);
    }
    
}