namespace CarBook.Application.Features.Mediator.Results.TagCloudResults;

public class GetTagCloudByIdQueryResult
{
    public int TagCloudId { get; set; }
    
    public string Tag { get; set; }
    
    public int BlogId { get; set; }
}