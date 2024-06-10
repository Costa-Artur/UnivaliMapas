using AutoMapper;
using UnivaliMapas.Api.Entities;
using UnivaliMapas.Api.Models;
using UnivaliMapas.Features.Usuarios.Commands.CreateUser;
using UnivaliMapas.Features.Usuarios.Queries.GetUsersDetail;

namespace UnivaliMapas.Api.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        
        CreateMap<Usuario, CreateUserDto>();
        CreateMap<UserForCreationDto, Usuario>();

        CreateMap<Usuario, GetUserDetailDto>();
    }
}