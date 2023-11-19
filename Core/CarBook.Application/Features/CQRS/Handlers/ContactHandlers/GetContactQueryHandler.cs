using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers;

public class GetContactQueryHandler
{
    private readonly IRepository<Contact> _repository;
    
    public GetContactQueryHandler(IRepository<Contact> repository)
    {
        _repository = repository;
    }
    
    public async Task<List<GetContactQueryResult>> Handle()
    {
        var contacts = await _repository.ListAllAsync();
        
        var contactsResults = contacts.Select(contact => new GetContactQueryResult()
        {
            ContactId = contact.ContactId,
            Name = contact.Name,
            CreatedAt = DateTime.Now,
            Email = contact.Email,
            Subject = contact.Subject,
            Message = contact.Message
        }).ToList();
        
        return contactsResults;
    }
    
}