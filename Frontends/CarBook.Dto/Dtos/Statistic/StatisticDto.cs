namespace CarBook.Dto.Dtos.Statistic;

public class StatisticDto
{
    public int CarCount { get; set; }
    public int BrandCount { get; set; }
    public int BlogCount { get; set; }
    public int AuthorCount { get; set; }
    public string HighestPriceCar { get; set; }
    public string LowestPriceCar { get; set; }
    public string MostRentedCarModel { get; set; }
    public string MinRentedCarModel { get; set;}
}