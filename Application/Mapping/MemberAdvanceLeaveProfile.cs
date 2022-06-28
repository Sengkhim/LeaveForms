using Application.Feature;
using AutoMapper;
using Domain;
using Domain.Entites;

namespace Application.Mapping
{
    public class AdvanceLeaveProfile : Profile
    {
        public AdvanceLeaveProfile()
        {
            CreateMap<AdvanceLeave, AdvanceLeaveResponse>().ReverseMap();
            CreateMap<MemberAdvanceLeave, MemberAdvanceLeaveResponse>()
            .ForMember<string>(r => r.FirstName, source => source.MapFrom<string>(source => source.Member.User!.FirstName))
            .ForMember<string>(r => r.LastName, source => source.MapFrom<string>(source => source.Member.User!.LastName))
            .ForMember<string>(r => r.Username, source => source.MapFrom(source => source.Member.User!.UserName))
            .ForMember<string>(r => r.Position, source => source.MapFrom<string>(source => source.Member.Position!.Name))
            .ForMember(r => r.FromDate, source => source.MapFrom(source => source.AdvanceLeave.FromDate))
            .ForMember(r => r.ToDate, source => source.MapFrom(source => source.AdvanceLeave.ToDate));
        }
    }
               
}

