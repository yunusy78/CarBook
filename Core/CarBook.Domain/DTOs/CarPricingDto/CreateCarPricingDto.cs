﻿namespace CarBook.Domain.DTOs.CarPricingDto;

public class CreateCarPricingDto
{
    public int CarId { get; set; }
    public int PricingId { get; set; }
    public decimal Price { get; set; }
}