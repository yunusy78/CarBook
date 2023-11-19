namespace CarBook.Application.Features.CQRS.Commands.BrandCommands;

public class DeleteBrandCommand
{
    public DeleteBrandCommand(int brandId)
    {
        BrandId = brandId;
    }

    public int BrandId { get; set; }
    
}