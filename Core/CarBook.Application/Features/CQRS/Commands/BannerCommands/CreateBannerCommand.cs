namespace CarBook.Application.Features.CQRS.Commands.BannerCommands;

public class CreateBannerCommand
{
    public string ImageUrl { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    
    public string VideoUrl { get; set; }
    
    public string VideoTitle { get; set; }
}