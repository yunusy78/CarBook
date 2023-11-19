using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers;

public class GetContactByIdQueryHandler
{
    private readonly IRepository<Contact> _repository;
    
    public GetContactByIdQueryHandler(IRepository<Contact> repository)
    {
        _repository = repository;
    }
    
    public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery request)
    {
      var contact=  await _repository.GetByIdAsync(request.ContactId);
        
        var contactDto = new GetContactByIdQueryResult()
        {
            ContactId = contact.ContactId,
            Name = contact.Name,
            CreatedAt = DateTime.Now,
            Email = contact.Email,
            Subject = contact.Subject,
            Message = contact.Message
        };
        
        return contactDto;
    }
}