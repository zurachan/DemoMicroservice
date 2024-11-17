using AutoMapper;
using OrderAPI.Domains;
using OrderAPI.Dto;

namespace OrderAPI.Common
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
        }
    }
}
