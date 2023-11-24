namespace CarBook.Application.Features.CQRS.Results.CarResults;

public class GetCarCategoryCountQueryResult
{
    public string CategoryName { get; set; }
    public int Count { get; set; }
}