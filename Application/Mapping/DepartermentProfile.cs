
using Application.Feature;
using AutoMapper;
using Domain;

namespace Application.Mapping
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentResponse>().ReverseMap();
        }
    }
}
