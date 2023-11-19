namespace CarBook.Application.Features.CQRS.Commands.ContactCommands;

public class DeleteContactCommand
{
    public int ContactId { get; set; }

    public DeleteContactCommand(int contactId)
    {
        ContactId = contactId;
    }
    
}