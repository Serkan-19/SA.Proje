using AutoMapper;
using SA.Model.Dtos.Employee;
using SA.Model.Entities;

namespace SA.Business.Profiles
{
    public class EmployeeMapperProfile : Profile
    {
        public EmployeeMapperProfile()
        {
            CreateMap<Employee, EmployeeGetDto>()
            .ForMember(dst => dst.IsciNo, x => x.MapFrom(src => src.EmployeeID))
            .ForMember(dst => dst.IscininAdi, x => x.MapFrom(src => src.FirstName))
            .ForMember(dst => dst.IscininSoyadi, x => x.MapFrom(src => src.LastName))
            .ForMember(dst => dst.IscininSehiri, x => x.MapFrom(src => src.City))
            .ForMember(dst => dst.IscininDogumTarihi, x => x.MapFrom(src => src.BirthDate))
            .ForMember(dst => dst.GemiAdi, x => x.MapFrom(src => src.Orders.Select(order => order.ShipName).FirstOrDefault()))
            .ForMember(dst => dst.GemiCikisTarihi, x => x.MapFrom(src => src.Orders.Select(order => order.ShippedDate).FirstOrDefault()));

            CreateMap<EmployeePostDto, Employee>()
            .ForMember(dst => dst.EmployeeID, x => x.MapFrom(src => src.IsciNo))
            .ForMember(dst => dst.FirstName, x => x.MapFrom(src => src.IscininAdi))
            .ForMember(dst => dst.LastName, x => x.MapFrom(src => src.IscininSoyadi))
            .ForMember(dst => dst.City, x => x.MapFrom(src => src.IscininSehiri))
            .ForMember(dst => dst.BirthDate, x => x.MapFrom(src => src.IscininDogumTarihi))
            .ForPath(dst => dst.Orders, x => x.MapFrom(src => new List<Order>
            {
                new Order
                {
                    ShipName = src.GemiAdi,
                    ShippedDate = src.GemiCikisTarihi
                }
            }));

            CreateMap<EmployeePutDto, Employee>()
            .ForMember(dst => dst.EmployeeID, x => x.MapFrom(src => src.IsciNo))
            .ForMember(dst => dst.FirstName, x => x.MapFrom(src => src.IscininAdi))
            .ForMember(dst => dst.LastName, x => x.MapFrom(src => src.IscininSoyadi))
            .ForMember(dst => dst.City, x => x.MapFrom(src => src.IscininSehiri))
            .ForMember(dst => dst.BirthDate, x => x.MapFrom(src => src.IscininDogumTarihi))
            .ForPath(dst => dst.Orders, x => x.MapFrom(src => new List<Order>
            {
                new Order
                {
                    ShipName = src.GemiAdi,
                    ShippedDate = src.GemiCikisTarihi
                }
            }));


        }
    }
}
