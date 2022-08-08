using Application.Conmon.Response.Identity;
using AutoMapper;
using Domain.Authentication;
using Domain.Entites;

namespace Application
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<Role, RoleResponse>().ReverseMap();
            CreateMap<RoleClaim, RoleClaimsResponse>().ReverseMap();
            CreateMap<UserRole, UserRolesResponse>().ReverseMap();
        }
    }
}
