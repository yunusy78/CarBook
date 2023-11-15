namespace CarBook.Application.Features.CQRS.Commands.AboutCommands;

public class DeleteAboutCommands
{
    public DeleteAboutCommands(int aboutId)
    {
        AboutId = aboutId;
    }

    public int AboutId { get; set; }
}