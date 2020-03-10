using AutoMapper;
using FruitRacers.Backend.Contracts.Addresses;
using FruitRacers.Backend.Contracts.Categories;
using FruitRacers.Backend.Contracts.Orders;
using FruitRacers.Backend.Contracts.Products;
using FruitRacers.Backend.Contracts.Suppliers;
using FruitRacers.Backend.Contracts.TimeSlots;
using FruitRacers.Backend.Contracts.Users;
using FruitRacers.Backend.Contracts.Users.Roles;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Entities.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace FruitRacers.Backend.Infrastructure.Mapping
{
    public static class MappingUtils
    {
        public static IMapper CreateDefaultMapper()
        {
            MapperConfiguration config = new MapperConfiguration(c =>
            {
                c.AddProfile<AddressMapping>();
                c.AddProfile<SupplierMapping>();
                c.AddProfile<OrderMapping>();
                c.AddProfile<UserMapping>();
                c.AddProfile<ProductMapping>();
                c.AddProfile<CategoriesMapping>();
                c.AddProfile<TimeSlotMapping>();
            });
            return config.CreateMapper();
        }

        private class AddressMapping : Profile
        {
            public AddressMapping()
            {
                CreateMap<Address, AddressOutputDto>();
            }
        }

        private class SupplierMapping : Profile
        {
            public SupplierMapping()
            {
                CreateMap<Supplier, SupplierInfoDto>()
                    .ForMember(dst => dst.Name, o => o.MapFrom(src => src.BusinessName))
                    .ForMember(dst => dst.SupplierId, o => o.MapFrom(src => src.UserId))
                    .ForMember(dst => dst.LogoImageUrl, o => o.MapFrom(src => src.LogoImage.Path))
                    .ForMember(dst => dst.BackgroundImageUrl, o => o.MapFrom(src => src.BackgroundImage.Path))
                    .ForMember(dst => dst.Address, o => o.MapFrom(src => src.User.Addresses.Single()));
            }
        }

        private class OrderMapping : Profile
        {
            public OrderMapping()
            {
                CreateMap<Order, DeliveryInfoOutputDto>();

                CreateMap<Order, CartOutputDto>()
                    .ForMember(dst => dst.DeliveryInfo, o => o.MapFrom(src => src));

                CreateMap<OrderSection, CartSectionDto>()
                    .ForMember(dst => dst.SupplierName, o => o.MapFrom(src => src.Supplier.BusinessName))
                    .ForMember(dst => dst.Items, o => o.MapFrom(src => src.Details));

                CreateMap<OrderDetail, CartItemOutputDto>();

                CreateMap<Order, SupplierOrderDto>()
                    .ForMember(dst => dst.DeliveryInfo, o => o.MapFrom(src => src));

                CreateMap<Order, CustomerOrderDto>()
                    .ForMember(dst => dst.DeliveryInfo, o => o.MapFrom(src => src));

                CreateMap<OrderSection, OrderSectionDto>()
                    .ForMember(dst => dst.SupplierAddress, o => o.MapFrom(src => src.Supplier.User.Addresses.First()))
                    .ForMember(dst => dst.SupplierName, o => o.MapFrom(src => src.Supplier.BusinessName))
                    .ForMember(dst => dst.Items, o => o.MapFrom(src => src.Details));

                CreateMap<OrderDetail, OrderDetailDto>();
            }
        }

        private class ProductMapping : Profile
        {
            public ProductMapping()
            {
                CreateMap<Price, PriceDto>();

                CreateMap<Product, ProductOutputDto>()
                    .ForMember(dst => dst.ImageUrl, o => o.MapFrom(src => src.Image.Path))
                    .ForMember(dst => dst.Prices, o => o.MapFrom((src, dst, m, context) => CreatePriceDictionary(src, context)));
            }

            private IDictionary<CustomerTypeDto, PriceDto> CreatePriceDictionary(Product product, IMapper mapper)
            {
                return product.Prices
                    .ToDictionary(p => (CustomerTypeDto)p.Type, mapper.Map<PriceDto>);
            }
        }

        private class UserMapping : Profile
        {
            public UserMapping()
            {
                CreateMap<Person, PersonDto>();

                CreateMap<CustomerBusiness, CustomerBusinessDto>();

                CreateMap<Supplier, SupplierDto>()
                    .ForMember(dst => dst.Address, o => o.MapFrom(src => src.User.Addresses.SingleOrDefault()));

                CreateMap<Administrator, AdministratorDto>();

                CreateMap<DeliveryCompany, DeliveryCompanyDto>();

                CreateMap<User, UserOutputDto>()
                    .ForMember(dst => dst.Roles, o => o.MapFrom(src => src.GetRoleTypes()))
                    .ForMember(dst => dst.RolesData, o => o.MapFrom((src, dst, m, context) => CreateRoleDictionary(src, context)));
            }

            private IDictionary<RoleTypeDto, RoleDto> CreateRoleDictionary(User source, IMapper mapper)
            {
                IDictionary<RoleTypeDto, RoleDto> roles = new Dictionary<RoleTypeDto, RoleDto>();
                if (source.Administrator != null)
                {
                    roles.Add(RoleTypeDto.Administrator, mapper.Map<AdministratorDto>(source.Administrator));
                }
                if (source.DeliveryCompany != null)
                {
                    roles.Add(RoleTypeDto.DeliveryCompany, mapper.Map<DeliveryCompanyDto>(source.DeliveryCompany));
                }
                if (source.Person != null)
                {
                    roles.Add(RoleTypeDto.Person, mapper.Map<PersonDto>(source.Person));
                }
                if (source.Supplier != null)
                {
                    roles.Add(RoleTypeDto.Supplier, mapper.Map<SupplierDto>(source.Supplier));
                }
                if (source.CustomerBusiness != null)
                {
                    roles.Add(RoleTypeDto.CustomerBusiness, mapper.Map<CustomerBusinessDto>(source.CustomerBusiness));
                }
                return roles;
            }
        }

        private class CategoriesMapping : Profile
        {
            public CategoriesMapping()
            {
                CreateMap<Category, CategoryDto>()
                    .ForMember(dst => dst.ImageUrl, o => o.MapFrom(src => src.Image.Path));
            }
        }

        private class TimeSlotMapping : Profile
        {
            public TimeSlotMapping()
            {
                CreateMap<TimeSlot, TimeSlotDto>();

                CreateMap<TimeSlot, TimeSlotWithCapacityDto>();
            }
        }
    }
}
