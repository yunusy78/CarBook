namespace CarBook.Application.Features.CQRS.Queries.CarQueries;

public class GetCarByLocationAndStatusQuery
{
    public GetCarByLocationAndStatusQuery(int locationId, bool isAvailable)
    {
        LocationId = locationId;
        IsAvailable = isAvailable;
    }
    
    public int LocationId { get; set; }
    public bool IsAvailable { get; set; }
}