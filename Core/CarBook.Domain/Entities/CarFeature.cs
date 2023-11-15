﻿namespace CarBook.Domain.Entities;

public class CarFeature
{
    
    public int CarFeatureId { get; set; }
    
    public int CarId { get; set; }
    
    public int FeatureId { get; set; }
    
    public Feature Feature { get; set; }
    
    public Car Car { get; set; }
    
    public bool IsAvailable { get; set; }
    
    
    
}