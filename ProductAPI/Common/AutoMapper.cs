using AutoMapper;
using ProductAPI.Domains;
using ProductAPI.Dto;

namespace ProductAPI.Common
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
