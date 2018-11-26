using AutoMapper;
using TestMVC.DTOs;
using TestMVC.Models;

namespace TestMVC
{
    public class AutoMapperConfiguration
    {
        public MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<UserDto, User>();
            });

            return config;
        }

    }
}
