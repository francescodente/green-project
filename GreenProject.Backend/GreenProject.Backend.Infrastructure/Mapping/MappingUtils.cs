using AutoMapper;
using GreenProject.Backend.Contracts.Addresses;
using GreenProject.Backend.Contracts.Cart;
using GreenProject.Backend.Contracts.Categories;
using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Contracts.PurchasableItems;
using GreenProject.Backend.Contracts.Users;
using GreenProject.Backend.Contracts.Users.Roles;
using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Entities.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace GreenProject.Backend.Infrastructure.Mapping
{
    public static class MappingUtils
    {
        public static IMapper CreateDefaultMapper()
        {
            MapperConfiguration config = new MapperConfiguration(c =>
            {
                c.AddProfile<AddressMapping>();
                c.AddProfile<CartMapping>();
                c.AddProfile<OrderMapping>();
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
                CreateMap<User, AddressCollectionDto>();

                CreateMap<Address, AddressOutputDto>()
                    .ForMember(dst => dst.Province, o => o.MapFrom(src => src.Zone.Province))
                    .ForMember(dst => dst.City, o => o.MapFrom(src => src.Zone.City));
            }
        }

        private class OrderMapping : Profile
        {
            public OrderMapping()
            {
                CreateMap<Order, DeliveryInfoOutputDto>();

                CreateMap<Order, OrderDto>()
                    .ForMember(dst => dst.DeliveryInfo, o => o.MapFrom(src => src))
                    .ForMember(dst => dst.Prices, o => o.MapFrom(src => src));

                CreateMap<Order, OrderPricesDto>();

                CreateMap<OrderDetail, OrderDetailDto>();
            }
        }

        private class CartMapping : Profile
        {
            public CartMapping()
            {
                CreateMap<CartItem, CartItemOutputDto>();
            }
        }

        private class ProductMapping : Profile
        {
            public ProductMapping()
            {
                CreateMap<Price, PriceDto>();

                CreateMap<Product, ProductOutputDto>()
                    .ForMember(dst => dst.ProductId, o => o.MapFrom(src => src.ItemId))
                    .ForMember(dst => dst.ImageUrl, o => o.MapFrom(src => src.Image.Path))
                    .ForMember(dst => dst.Price, o => o.MapFrom(src => src.Prices.First(p => p.Type == CustomerType.Person)));

                CreateMap<Crate, CrateOutputDto>()
                    .ForMember(dst => dst.CrateId, o => o.MapFrom(src => src.ItemId))
                    .ForMember(dst => dst.Price, o => o.MapFrom(src => src.Prices.First(p => p.Type == CustomerType.Person).Value))
                    .ForMember(dst => dst.CompatibleProducts, o => o.MapFrom(src => src.Compatibilities));
            }
        }

        private class UserMapping : Profile
        {
            public UserMapping()
            {
                CreateMap<Person, PersonDto>();

                CreateMap<CustomerBusiness, CustomerBusinessDto>();

                CreateMap<DeliveryMan, DeliveryManDto>();

                CreateMap<User, UserOutputDto>()
                    .ForMember(dst => dst.Roles, o => o.MapFrom(src => src.GetRoleTypes()))
                    .ForMember(dst => dst.RolesData, o => o.MapFrom((src, dst, m, context) => CreateRoleDictionary(src, context)));
            }

            private IDictionary<RoleTypeDto, RoleDto> CreateRoleDictionary(User source, IMapper mapper)
            {
                IDictionary<RoleTypeDto, RoleDto> roles = new Dictionary<RoleTypeDto, RoleDto>();
                if (source.DeliveryCompany != null)
                {
                    roles.Add(RoleTypeDto.DeliveryMan, mapper.Map<DeliveryManDto>(source.DeliveryCompany));
                }
                if (source.Person != null)
                {
                    roles.Add(RoleTypeDto.Person, mapper.Map<PersonDto>(source.Person));
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
    }
}
