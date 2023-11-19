namespace CarBook.Application.Features.CQRS.Queries.BrandQueries;

public class GetBrandByIdQuery
{
    public GetBrandByIdQuery(int brandId)
    {
        BrandId = brandId;
    }
    
    public int BrandId { get; set; }
}