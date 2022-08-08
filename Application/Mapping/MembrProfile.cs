using Application.Feature;
using AutoMapper;
using Domain;

namespace Application.Mapping
{
    public class MembrProfile : Profile
    {
        public MembrProfile()
        {
            CreateMap<Member, MemberResponse>()
            .ForMember(r => r.FirstName, source => source.MapFrom(source => source.User!.FirstName))
            .ForMember(r => r.LastName, source => source.MapFrom(source => source.User!.LastName))
            .ForMember(r => r.Username, source => source.MapFrom(source => source.User!.UserName))
            .ForMember(r => r.Position, source => source.MapFrom(source => source.Position!.Name))
            .ForMember(r => r.Email, source => source.MapFrom(source => source.User!.Email))
            .ForMember(r => r.PhoneNumber, source => source.MapFrom(source => source.User!.PhoneNumber))
            .ForMember(r => r.MemberAdvanceLeaveResponse, source => source.MapFrom(source => source.MemberAdvanceLeave))
            .ForMember(r => r.MemberActaulLeaveResponse, source => source.MapFrom(source => source.MemberActualLeave))
            .ForMember(r => r.Departerment, source => source.MapFrom(source => source.Departerment!.Name));
        }
    }

}
