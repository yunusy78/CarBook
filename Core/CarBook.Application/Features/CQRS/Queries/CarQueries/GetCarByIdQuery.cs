namespace CarBook.Application.Features.CQRS.Queries.CarQueries;

public class GetCarByIdQuery
{
    public GetCarByIdQuery(int CarId)
    {
        CarId = CarId;
    }
    
    public int CarId { get; set; }
}