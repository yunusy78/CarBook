namespace CarBook.Application.Features.CQRS.Commands.CarCommands;

public class DeleteCarCommand
{
    public int CarId { get; set; }

    public DeleteCarCommand(int carId)
    {
        CarId = carId;
    }

}