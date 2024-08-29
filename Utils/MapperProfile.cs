using AutoMapper;
using SalesWS.Contexts;
using SalesWS.DTOs;

namespace SalesWS.Utils
{
    public class MapperProfile : Profile
    {

        public MapperProfile()
        {
            CreateMap<Product, ProductDTO> ().ReverseMap();
            CreateMap<ProductDTO, Product>();
            CreateMap<Shipper, ShipperDTO>().ReverseMap();
            CreateMap<ShipperDTO, Shipper>();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<CustomerDTO, Customer>();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<EmployeeDTO, Employee>();
        }
    }
}
