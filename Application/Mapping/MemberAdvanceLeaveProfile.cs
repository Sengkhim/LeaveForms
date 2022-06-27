using Application.Feature;
using AutoMapper;
using Domain;

namespace Application.Mapping
{
    public class MemberAdvanceLeaveProfile : Profile
    {
        public MemberAdvanceLeaveProfile()
        {
            CreateMap<MemberAdvanceLeaveRequest, MemberAdvanceLeaveRequestResponse>()
            .ForMember(r => r.FirstName, source => source.MapFrom(source => source.Member.User.FirstName))
            .ForMember(r => r.LastName, source => source.MapFrom(source => source.Member.User!.LastName))
            .ForMember(r => r.Username, source => source.MapFrom(source => source.Member.User!.UserName))
            .ForMember(r => r.Position, source => source.MapFrom(source => source.Member.Position!.Name))
            .ForMember(r => r.FromDate, source => source.MapFrom(source => source.AdvanceLeave.FromDate))
            .ForMember(r => r.ToDate, source => source.MapFrom(source => source.AdvanceLeave.ToDate));
        }
    }
    public class AdvanceLeaveProfile : Profile
    {
        public AdvanceLeaveProfile()
        {
            CreateMap<AdvanceLeave, AdvanceLeaveResponse>().ReverseMap();
        }
    }

}

