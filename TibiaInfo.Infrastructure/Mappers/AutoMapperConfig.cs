using System;
using AutoMapper;
using TibiaInfo.Core.Models;
using TibiaInfo.Infrastructure.DTO;

namespace TibiaInfo.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
    public static IMapper Initialize()
        => new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, UserDTO>();
        })
        .CreateMapper();
    }
}