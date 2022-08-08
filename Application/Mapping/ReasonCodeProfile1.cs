using Application.Feature;
using AutoMapper;
using Domain;

namespace Application
{
    public class ReasonCodeProfile : Profile
    {
        public ReasonCodeProfile()
        {
            CreateMap<ReasonCode, ReasonCodeResponse>().ReverseMap();
        }
    }
}
