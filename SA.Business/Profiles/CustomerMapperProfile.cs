using AutoMapper;
using SA.Model.Dtos.Customer;
using SA.Model.Entities;

namespace SA.Business.Profiles
{
    public class CustomerMapperProfile : Profile
    {
        public CustomerMapperProfile()
        {
            CreateMap<Customer, CustomerGetDto>()
            .ForMember(dst => dst.MusteriNo, x => x.MapFrom(src => src.CustomerID))
            .ForMember(dst => dst.SirketAdi, x => x.MapFrom(src => src.CompanyName))
            .ForMember(dst => dst.SirketYetkilisi, x => x.MapFrom(src => src.ContactName))
            .ForMember(dst => dst.EmirZamani, x => x.MapFrom(src => src.Orders.Select(x => x.OrderDate)));
            CreateMap<CustomerPostDto, Customer>()
            .ForMember(dst => dst.CustomerID, x => x.MapFrom(src => src.MusteriNo))
            .ForMember(dst => dst.CompanyName, x => x.MapFrom(src => src.SirketAdi))
            .ForMember(dst => dst.ContactName, x => x.MapFrom(src => src.SirketYetkilisi))
            .ForPath(dst => dst.Orders, x => x.MapFrom(src => new List<Order> {


                new Order
                {
                    OrderDate = src.EmirZamani,

                }}
            ));

            CreateMap<CustomerPutDto, Customer>()
            .ForMember(dst => dst.CustomerID, x => x.MapFrom(src => src.MusteriNo))
            .ForMember(dst => dst.CompanyName, x => x.MapFrom(src => src.SirketAdi))
            .ForMember(dst => dst.ContactName, x => x.MapFrom(src => src.SirketYetkilisi))
           .ForPath(dst => dst.Orders, x => x.MapFrom(src => new List<Order>
            {

                new Order
                {
                 OrderDate = src.EmirZamani
                }



            }));


        }
    }
}
