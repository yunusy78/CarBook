namespace CarBook.Application.Features.CQRS.Results.BannerResults;

public class GetBannerQueryResult
{
    public int BannerId { get; set; }
    
    public string ImageUrl { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public string VideoUrl { get; set; }
    
    public string VideoTitle { get; set; }
}