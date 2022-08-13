
using Application.Conmon;
using AutoMapper;
using Domain.Entites.Chat;

namespace Application.Mapping
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomViewModel>();
            CreateMap<RoomViewModel, Room>();
        }
    }
}
