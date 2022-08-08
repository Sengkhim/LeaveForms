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
            CreateMap<AdvanceLeave, AdvanceLeaveResponse>()
            .ForMember(r => r.MemberAdvanceLeaveResponse, source => source.MapFrom(source => source.MemberAdvanceLeave));

            CreateMap<MemberAdvanceLeave, MemberAdvanceLeaveResponse>()
            .ForMember(r => r.FirstName, source => source.MapFrom(source => source.Member!.User!.FirstName))
            .ForMember(r => r.LastName, source => source.MapFrom(source => source.Member!.User!.LastName))
            .ForMember(r => r.Username, source => source.MapFrom(source => source.Member!.User!.UserName))
            .ForMember(r => r.Departerment, source => source.MapFrom(source => source.Member!.Departerment!.Name))
            .ForMember(r => r.Description, source => source.MapFrom(source => source.Member!.Description))
            .ForMember(r => r.Position, source => source.MapFrom(source => source.Member!.Position!.Name))
            .ForMember(r => r.FromDate, source => source.MapFrom(source => source.AdvanceLeave!.FromDate))
            .ForMember(r => r.ReasonCode, source => source.MapFrom(source => source.AdvanceLeave!.ReasonCode!.Code))
            .ForMember(r => r.ReasonCodeDescription, source => source.MapFrom(source => source.AdvanceLeave!.ReasonCode!.Description))
            .ForMember(r => r.ToDate, source => source.MapFrom(source => source.AdvanceLeave!.ToDate));
           
        }
    }
               
}

