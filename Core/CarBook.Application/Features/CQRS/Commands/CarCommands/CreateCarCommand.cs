﻿namespace CarBook.Application.Features.CQRS.Commands.CarCommands;

public class CreateCarCommand
{
    public int BrandId { get; set; }
    
    public string Model { get; set; }
    
    public int LocationId { get; set; }
    
    public int Year { get; set; }
    
    public string Color { get; set; }
    
    public string ImageUrl { get; set; }
    
    public int Price { get; set; }
    
    public int Mileage { get; set; }
    
    public byte Seats { get; set; }
    
    public byte Luggage { get; set; }
    
    public byte Doors { get; set; }
    
    public bool IsAvailable { get; set; }
    
    public string Transmission { get; set; }
    
    public string Fuel { get; set; }
    
    public int CategoryId { get; set; }
}