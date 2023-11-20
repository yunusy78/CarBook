using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BlogCommands;

public class UpdateBlogCommand : IRequest
{
    
    public int BlogId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    public string ImageUrl { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
    public int AuthorId { get; set; }
    public string CoverImage { get; set; }
    public int CategoryId { get; set; }
}
