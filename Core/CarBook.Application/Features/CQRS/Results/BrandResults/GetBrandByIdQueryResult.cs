namespace CarBook.Application.Features.CQRS.Results.BrandResults;

public class GetBrandByIdQueryResult
{
    public int BrandId { get; set; }
    
    public string BrandName { get; set; }
}