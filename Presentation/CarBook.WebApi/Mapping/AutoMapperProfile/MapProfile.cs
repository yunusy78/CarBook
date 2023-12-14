using AutoMapper;
using CarBook.Domain.DTOs;
using CarBook.Domain.DTOs.CarFeatureDto;
using CarBook.Domain.DTOs.CarPricingDto;
using CarBook.Domain.Entities;
using CarBook.Dto.Dtos.CarDto;
using CarBook.Dto.Dtos.ReservationDto;

namespace CarBook.WebApi.Mapping.AutoMapperProfile;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<CommentDto, Comment>();
        CreateMap<Comment, CommentDto>();
        CreateMap<CarPricing, CarPricingDto>();
        CreateMap<CarPricingDto, CarPricing>();
        CreateMap<CreateCarPricingDto, CarPricing>();
        CreateMap<UpdateCarPricingDto, CarPricing>();
        CreateMap<Car, CarDto>();
        CreateMap<CarDto, Car>();
        CreateMap<CreateCarDto, Car>();
        CreateMap<UpdateCarDto, Car>();
        CreateMap<CreateReservationDto, ReservationCar>();
        CreateMap<UpdateReservationDto, ReservationCar>();
        CreateMap<CreateCarFeatureDto, CarFeature>();
        CreateMap<UpdateCarFetaureDto, CarFeature>();
       
        
    }
    
}