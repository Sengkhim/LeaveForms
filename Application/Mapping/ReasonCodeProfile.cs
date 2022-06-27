using Application.Feature;
using AutoMapper;
using Domain;

namespace Application.Mapping
{
    public class ReasonCodeProfile : Profile
    {
        public ReasonCodeProfile()
        {
            CreateMap<ReasonCode, ReasonCodeResponse>();
            CreateMap<ReasonCodeRecord, ReasonCodeRecordResponse>()
            .ForMember(r => r.RecordStatusTypeCode, source => source.MapFrom(source => source.RecordStatusType!.Code))
            .ForMember(r => r.BeginDate, source => source.MapFrom(source => source.Period!.BeginDate))
            .ForMember(r => r.EndDate, source => source.MapFrom(source => source.Period!.EndDate));
        }
    }
}
