namespace CarBook.Application.Features.CQRS.Commands.CategoryCommands;

public class DeleteCategoryCommand
{
    public DeleteCategoryCommand(int categoryId)
    {
        CategoryId = categoryId;
    }

    public int CategoryId { get; set; }
    
    
}