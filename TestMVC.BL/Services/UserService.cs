using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using TestMVC.DTOs;
using TestMVC.Models;
using TestMVC.Repositories;

namespace TestMVC.Services
{
    public class UserService
    {
        private UserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IMapper mapper)
        {
            this.mapper = mapper;
            userRepository = new UserRepository();
        }
        public UserDto GetById(int id)
        {
            var item = userRepository.GetById(id);
            return mapper.Map<User, UserDto>(item);
        }

        public List<User> GetAll()
        {
            var users = userRepository.GetAll()?.OrderBy(x => x?.UserName)?.ToList();

            return users;
        }

        public UserDto Add(UserDto dto)
        {
            dto.Id = userRepository.GetMaxId() + 1;
            var item = userRepository.Add(mapper.Map<UserDto, User>(dto));

            if (item != null)
            {
                return mapper.Map<User, UserDto>(item);
            }
            else
            {
                return null;
            }
        }

        public UserDto Remove(int id)
        {
            return mapper.Map<User, UserDto>(userRepository.Remove(id));
        }

    }
}
