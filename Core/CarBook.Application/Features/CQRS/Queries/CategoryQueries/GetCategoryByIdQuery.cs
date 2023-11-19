namespace CarBook.Application.Features.CQRS.Queries.CategoryQueries;

public class GetCategoryByIdQuery
{
    public int CategoryId { get; set; }
    
    public GetCategoryByIdQuery(int categoryId)
    {
        CategoryId = categoryId;
    }
    
    
}