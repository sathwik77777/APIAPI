using AutoMapper;
using CodingCha.DTO;
using CodingCha.Entities;

namespace CodingCha.Profiles
{
    public class UserProfile : Profile

    {
        public UserProfile()
        {
            CreateMap<User,UserDTO>();
            CreateMap<UserDTO,User>();
        }

    }
}
