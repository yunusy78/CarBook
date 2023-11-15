namespace CarBook.Application.Features.CQRS.Queries.BannerQueries;

public class GetBannerByIdQuery
{
    public GetBannerByIdQuery(int bannerId)
    {
        BannerId = bannerId;
    }

    public int BannerId { get; set; }
    
    
    
}