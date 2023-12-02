using AutoMapper;
using CarBook.Domain.DTOs;
using CarBook.Domain.Entities;

namespace CarBook.WebApi.Mapping.AutoMapperProfile;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<CommentDto, Comment>();
        CreateMap<Comment, CommentDto>();
    }
    
}