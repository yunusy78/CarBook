namespace CarBook.Application.Features.CQRS.Queries.ContactQueries;

public class GetContactByIdQuery
{
    public GetContactByIdQuery(int contactId)
    {
        ContactId = contactId;
    }
    
    public int ContactId { get; set; }
}