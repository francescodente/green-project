using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using FruitRacers.Backend.Core.Dto;
using FruitRacers.Backend.Core.Entities;
using System.Linq;

namespace FruitRacers.Backend.Core.Services.Utils
{
    public static class MappingUtils
    {
        public static IMapper CreateDefaultMapper()
        {
            MapperConfiguration config = new MapperConfiguration(c =>
            {
                c.AddProfile<AddressMapping>();
                c.AddProfile<OrderMapping>();
                c.AddProfile<TimeSlotMapping>();
                c.AddProfile<UserMapping>();
                c.AddProfile<ProductMapping>();
                c.AddProfile<CategoriesMapping>();
            });
            return config.CreateMapper();
        }

        private class AddressMapping : Profile
        {
            public AddressMapping()
            {
                this.CreateMap<Address, AddressDto>();
            }
        }

        private class OrderMapping : Profile
        {
            public OrderMapping()
            {
                this.CreateMap<Order, DeliveryInfoDto>();

                this.CreateMap<OrderDetail, CartItemDto>();

                this.CreateMap<Order, CartDto>()
                    .ForMember(dst => dst.DeliveryInfo, o => o.MapFrom(src => src));

                this.CreateMap<OrderDetail, OrderDetailDto>();

                this.CreateMap<Order, OrderDto>()
                    .ForMember(dst => dst.DeliveryInfo, o => o.MapFrom(src => src));
            }
        }

        private class TimeSlotMapping : Profile
        {
            public TimeSlotMapping()
            {
                this.CreateMap<TimeSlot, TimeSlotDto>();
            }
        }

        private class ProductMapping : Profile
        {
            public ProductMapping()
            {
                this.CreateMap<Product, SimpleProductDto<CategoryDto>>();
            }
        }

        private class UserMapping : Profile
        {
            public UserMapping()
            {
                this.CreateMap<User, SimpleUserDto>();

                this.CreateMap<User, LoggedInUserDto>()
                    .ForMember(dst => dst.IsAdmin, o => o.MapFrom(src => src.UserAdministrator != null))
                    .ForMember(dst => dst.IsDeliveryCompany, o => o.MapFrom(src => src.UserDeliveryCompany != null));

                this.CreateMap<UserPerson, PersonDto>();

                this.CreateMap<UserBusinessCustomer, CustomerBusinessDto>()
                    .ForMember(dst => dst.LegalForm, o => o.MapFrom(src => src.User.LegalForm))
                    .ForMember(dst => dst.BusinessName, o => o.MapFrom(src => src.User.BusinessName))
                    .ForMember(dst => dst.Pec, o => o.MapFrom(src => src.User.Pec))
                    .ForMember(dst => dst.Sdi, o => o.MapFrom(src => src.User.Sdi))
                    .ForMember(dst => dst.VatNumber, o => o.MapFrom(src => src.User.VatNumber));

                this.CreateMap<UserBusinessSupplier, SupplierDto>()
                    .ForMember(dst => dst.Address, o => o.MapFrom(src => src.User.User.Addresses.SingleOrDefault()))
                    .ForMember(dst => dst.LegalForm, o => o.MapFrom(src => src.User.LegalForm))
                    .ForMember(dst => dst.BusinessName, o => o.MapFrom(src => src.User.BusinessName))
                    .ForMember(dst => dst.Pec, o => o.MapFrom(src => src.User.Pec))
                    .ForMember(dst => dst.Sdi, o => o.MapFrom(src => src.User.Sdi))
                    .ForMember(dst => dst.VatNumber, o => o.MapFrom(src => src.User.VatNumber));
            }
        }

        private class CategoriesMapping : Profile
        {
            public CategoriesMapping()
            {
                this.CreateMap<Category, CategoryDto>()
                    .ForMember(dst => dst.ImageUrl, o => o.MapFrom(src => src.Image.Path));
            }
        }
    }
}
