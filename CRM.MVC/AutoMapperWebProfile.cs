using CRM.Models;
using CRM.MVC.ViewModels;

namespace CRM.MVC
{
    public class AutoMapperWebProfile : AutoMapper.Profile
    {
        public static void Run() => AutoMapper.Mapper.Initialize(a => { a.AddProfile<AutoMapperWebProfile>(); });
        public AutoMapperWebProfile()
        {
            AllowNullDestinationValues = true;

            CreateMap<Client, ClientDto>()
           .ReverseMap();

            CreateMap<Order, OrdersShowDto>()
            .ForMember(Dto => Dto.ClientId, opt => opt.MapFrom(order => order.Client.Id))
            .ForMember(Dto => Dto.ClientName, opt => opt.MapFrom(order => order.Client.Name))
            .ReverseMap();


            CreateMap<Order, OrdersAddDto>()
            .ForMember(Dto => Dto.ClientId, opt => opt.MapFrom(order => order.ClientId))
            .ReverseMap();


            CreateMap<OrderRevenue, OrderRevenuesShowDto>()
            .ReverseMap();

            CreateMap<OrderExpense, OrderExpensesShowDto>()
            .ReverseMap();


            CreateMap<Order, OrderRevenuesAddDto>()
                     .ForMember(Dto => Dto.OrderId, opt => opt.MapFrom(order => order.Id))
            .ReverseMap();

            CreateMap<CompanyExpense, CompanyExpensesDto>()
             .ReverseMap();
        }
    }
}