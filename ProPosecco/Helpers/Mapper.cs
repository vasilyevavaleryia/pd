using AutoMapper;
using ProPosecco.Areas.Identity.Data;
using ProPosecco.Areas.Identity.Data.Entities;
using ProProsecco.Helpers.ExtensionMethods;
using ProProsecco.Models.Carts;
using ProProsecco.Models.Orders;
using ProProsecco.Models.User;
using ProProsecco.Models.Wine;
using System.Linq;

namespace ProProsecco.Helpers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            WineMappings();
            UserMappings();
            CartMappings();
            OrderMappings();
        }

        void WineMappings()
        {
            CreateMap<Wine, WineGetModel>()
                 .ForMember(dest => dest.Color, map => map.MapFrom(src => src.Color.GetDisplayName()))
                .ForMember(dest => dest.ProductionCountry, map => map.MapFrom(src => src.ProductionCountry.GetDisplayName()))
                .ForMember(dest => dest.Taste, map => map.MapFrom(src => src.Taste.GetDisplayName()));

            CreateMap<WineCreateModel, Wine>();
            CreateMap<WineUpdateModel, Wine>();
            CreateMap<Wine, WineUpdateModel>();
        }

        void UserMappings()
        {
            CreateMap<User, UserGetModelAdminView>()
                .ForMember(dest => dest.FirstName, map => map.MapFrom(src => src.UserDetails.FirstName))
                .ForMember(dest => dest.Surname, map => map.MapFrom(src => src.UserDetails.Surname))
                .ForMember(dest => dest.City, map => map.MapFrom(src => src.UserDetails.City));

            CreateMap<User, UserGetModel>()
                .ForMember(dest => dest.FirstName, map => map.MapFrom(src => src.UserDetails.FirstName))
                .ForMember(dest => dest.Surname, map => map.MapFrom(src => src.UserDetails.Surname))
                .ForMember(dest => dest.City, map => map.MapFrom(src => src.UserDetails.City))
                .ForMember(dest => dest.HouseNumber, map => map.MapFrom(src => src.UserDetails.HouseNumber))
                .ForMember(dest => dest.Street, map => map.MapFrom(src => src.UserDetails.Street))
                .ForMember(dest => dest.ZipCode, map => map.MapFrom(src => src.UserDetails.ZipCode))
                .ForMember(dest => dest.Carts, map => map.MapFrom(src => src.Carts.Where(c => !c.IsUsed).ToList()))
                .ForMember(dest => dest.Orders, map => map.MapFrom(src => src.Carts.Where(c => c.Order.IsPaid).Select(c => c.Order).ToList()));
        }

        void CartMappings()
        {
            CreateMap<Cart, CartGetModel>()
                .ForMember(dest => dest.TotalPrice, map => map.MapFrom(src => src.CartItems.Sum(i => i.Wine.Price * i.Amount)));
        }

        void OrderMappings()
        {
            CreateMap<Order, OrderGetModel>();
        }
    }
}
