using AutoMapper;
using CarBook.Dto.Dtos.CarDto;


namespace OrderApplication.Mapping;

public class CustomMapper : Profile
{
    public CustomMapper()
    {
        CreateMap<CarDto, CreateCarDto>().ReverseMap();
        CreateMap<CreateCarDto, CarDto>();

    }

}