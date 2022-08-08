using Application.Feature;
using AutoMapper;
using Domain;

namespace Application.Mapping
{
    public class ActualLeaveProfile : Profile
    {
        public ActualLeaveProfile()
        {
            CreateMap<ActualLeave, ActualLeaveResponse>()
              .ForMember(r => r.MemberActaulLeaveResponse!, source => source.MapFrom(source => source.MemberActualLeave));

            CreateMap<MemberActualLeave, MemberActaulLeaveResponse>()
              .ForMember(r => r.FirstName!, source => source.MapFrom(source => source.Member!.User!.FirstName))
              .ForMember(r => r.LastName!, source => source.MapFrom(source => source.Member!.User!.LastName))
              .ForMember(r => r.Username!, source => source.MapFrom(source => source.Member!.User!.UserName))
              .ForMember(r => r.Position!, source => source.MapFrom(source => source.Member!.Position!.Name))
              .ForMember(r => r.Description!, source => source.MapFrom(source => source.Member!.Description))
              .ForMember(r => r.Departerment!, source => source.MapFrom(source => source.Member!.Departerment!.Name))
              .ForMember(r => r.FromDate, source => source.MapFrom(source => source.ActualLeave!.FromDate))
              .ForMember(r => r.ReasonCode, source => source.MapFrom(source => source.ActualLeave!.ReasonCode!.Code))
              .ForMember(r => r.ReasonCodeDescription, source => source.MapFrom(source => source.ActualLeave!.ReasonCode!.Description))
              .ForMember(r => r.ToDate, source => source.MapFrom(source => source.ActualLeave!.ToDate));
        }
    }
}
