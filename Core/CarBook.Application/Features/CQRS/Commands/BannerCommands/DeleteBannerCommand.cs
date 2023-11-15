namespace CarBook.Application.Features.CQRS.Commands.BannerCommands;

public class DeleteBannerCommand
{
    public DeleteBannerCommand(int bannerId)
    {
        BannerId = bannerId;
    }

    public int BannerId { get; set; }
    
}