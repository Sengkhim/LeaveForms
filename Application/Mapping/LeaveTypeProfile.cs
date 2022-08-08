using Application.Feature;
using AutoMapper;
using Domain;

namespace Application.Mapping
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveType, LeaveTypeResponse>().ReverseMap();
        }
    }
}
