using AutoMapper;
using SA.Model.Dtos.Order;
using SA.Model.Entities;


namespace SA.Business.Profiles
{
    public class OrderMapperProfile : Profile
    {
        public OrderMapperProfile()
        {
            CreateMap<Order, OrderGetDto>()
            .ForMember(dst => dst.EmirNo, x => x.MapFrom(src => src.OrderID))
            .ForMember(dst => dst.SirketAdi, x => x.MapFrom(src => src.Customer.CompanyName))
            .ForMember(dst => dst.IscininAdi, x => x.MapFrom(src => src.Employee.FirstName))
            .ForMember(dst => dst.IscininSoyadi, x => x.MapFrom(src => src.Employee.LastName))
            .ForMember(dst => dst.GemiCikisTarihi, x => x.MapFrom(src => src.ShippedDate))
            .ForMember(dst => dst.GemiAdi, x => x.MapFrom(src => src.ShipName));
            CreateMap<OrderPostDto, Order>()
            .ForMember(dst => dst.OrderID, x => x.MapFrom(src => src.EmirNo))
            .ForPath(dst => dst.Customer.CompanyName, x => x.MapFrom(src => src.SirketAdi))
            .ForPath(dst => dst.Employee.FirstName, x => x.MapFrom(src => src.IscininAdi))
            .ForPath(dst => dst.Employee.LastName, x => x.MapFrom(src => src.IscininSoyadi))
            .ForMember(dst => dst.ShippedDate, x => x.MapFrom(src => src.GemiCikisTarihi))
            .ForMember(dst => dst.ShipName, x => x.MapFrom(src => src.GemiAdi));
            CreateMap<OrderPutDto, Order>()
            .ForMember(dst => dst.OrderID, x => x.MapFrom(src => src.EmirNo))
            .ForPath(dst => dst.Customer.CompanyName, x => x.MapFrom(src => src.SirketAdi))
            .ForPath(dst => dst.Employee.FirstName, x => x.MapFrom(src => src.IscininAdi))
            .ForPath(dst => dst.Employee.LastName, x => x.MapFrom(src => src.IscininSoyadi))
            .ForMember(dst => dst.ShippedDate, x => x.MapFrom(src => src.GemiCikisTarihi))
            .ForMember(dst => dst.ShipName, x => x.MapFrom(src => src.GemiAdi));


        }
    }


}

