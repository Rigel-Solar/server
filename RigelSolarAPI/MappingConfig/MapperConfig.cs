using AutoMapper;
using RigelSolarAPI.Dto;
using RigelSolarAPI.Models;

namespace RigelSolarAPI.MappingConfig;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<ClienteDTO, Cliente>();
    }
}
