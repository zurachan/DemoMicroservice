using AutoMapper;
using CustomerAPI.Domain;
using CustomerAPI.Dto;

namespace CustomerAPI.Common
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
