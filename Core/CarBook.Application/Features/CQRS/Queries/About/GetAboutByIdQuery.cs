namespace CarBook.Application.Features.CQRS.Queries.About;

public class GetAboutByIdQuery
{
    public GetAboutByIdQuery(int aboutId)
    {
        AboutId = aboutId;
    }   
    public int AboutId { get; set; }
}