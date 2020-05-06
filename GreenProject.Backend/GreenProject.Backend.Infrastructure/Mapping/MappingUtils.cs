using AutoMapper;
using GreenProject.Backend.Contracts.Addresses;
using GreenProject.Backend.Contracts.Cart;
using GreenProject.Backend.Contracts.Categories;
using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Contracts.Orders.Delivery;
using GreenProject.Backend.Contracts.PurchasableItems;
using GreenProject.Backend.Contracts.Users;
using GreenProject.Backend.Contracts.Users.Roles;
using GreenProject.Backend.Contracts.WeeklyOrders;
using GreenProject.Backend.Core.Utils.Pricing;
using GreenProject.Backend.Entities;
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
                c.AddProfile<WeeklyOrdersMapping>();
            });
            return config.CreateMapper();
        }

        private class AddressMapping : Profile
        {
            public AddressMapping()
            {
                CreateMap<User, AddressCollectionDto>();

                CreateMap<Address, AddressDto.Output>();
            }
        }

        private class OrderMapping : Profile
        {
            public OrderMapping()
            {
                CreateMap<Order, DeliveryInfoDto.Output>();

                CreateMap<Order, OrderDto>()
                    .ForMember(dst => dst.DeliveryInfo, o => o.MapFrom(src => src))
                    .ForMember(dst => dst.Prices, o => o.MapFrom(src => src));

                CreateMap<Order, OrderPricesDto>();

                CreateMap<OrderDetail, OrderDetailDto>()
                    .ForMember(dst => dst.UnitName, o => o.MapFrom(src => ((Product)src.Item).UnitName))
                    .ForMember(dst => dst.UnitMultiplier, o => o.MapFrom(src => ((Product)src.Item).UnitMultiplier))
                    .ForMember(dst => dst.Name, o => o.MapFrom(src => src.Item.Name))
                    .ForMember(dst => dst.Description, o => o.MapFrom(src => src.Item.Description))
                    .ForMember(dst => dst.ImageUrl, o => o.MapFrom(src => src.Item.Image.Path));
            }
        }

        private class CartMapping : Profile
        {
            public CartMapping()
            {
                CreateMap<User, CartDto>();

                CreateMap<CartItem, QuantifiedProductDto.Output>();
            }
        }

        private class ProductMapping : Profile
        {
            public ProductMapping()
            {
                CreateMap<Product, ProductDto.Output>()
                    .ForMember(dst => dst.ProductId, o => o.MapFrom(src => src.ItemId))
                    .ForMember(dst => dst.ImageUrl, o => o.MapFrom(src => src.Image.Path));

                CreateMap<Crate, CrateDto.Output>()
                    .ForMember(dst => dst.CrateId, o => o.MapFrom(src => src.ItemId))
                    .ForMember(dst => dst.ImageUrl, o => o.MapFrom(src => src.Image.Path));

                CreateMap<CrateCompatibility, CompatibilityDto.Output>();
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
                    .ForMember(dst => dst.RolesData, o => o.MapFrom((src, dst, m, context) => CreateRoleDictionary(src, context)));
            }

            private IDictionary<RoleType, RoleDto> CreateRoleDictionary(User source, IMapper mapper)
            {
                IDictionary<RoleType, RoleDto> roles = new Dictionary<RoleType, RoleDto>();
                if (source.DeliveryCompany != null)
                {
                    roles.Add(RoleType.DeliveryMan, mapper.Map<DeliveryManDto>(source.DeliveryCompany));
                }
                if (source.Person != null)
                {
                    roles.Add(RoleType.Person, mapper.Map<PersonDto>(source.Person));
                }
                if (source.CustomerBusiness != null)
                {
                    roles.Add(RoleType.CustomerBusiness, mapper.Map<CustomerBusinessDto>(source.CustomerBusiness));
                }
                return roles;
            }
        }

        private class CategoriesMapping : Profile
        {
            public CategoriesMapping()
            {
                CreateMap<Category, CategoryDto.Output>()
                    .ForMember(dst => dst.ImageUrl, o => o.MapFrom(src => src.Image.Path));

                CreateMap<Category, CategoryDto.Tree>()
                    .ForMember(dst => dst.ImageUrl, o => o.MapFrom(src => src.Image.Path));
            }
        }

        private class WeeklyOrdersMapping : Profile
        {
            public WeeklyOrdersMapping()
            {
                CreateMap<Order, WeeklyOrderDto>()
                    .ForMember(dst => dst.DeliveryInfo, o => o.MapFrom(src => src))
                    .ForMember(dst => dst.Prices, o => o.MapFrom(src => src))
                    .ForMember(dst => dst.Crates, o => o.MapFrom(src => src.Details.Where(d => d.Item is Crate)))
                    .ForMember(dst => dst.ExtraProducts, o => o.MapFrom(src => src.Details.Where(d => d.Item is Product)));

                CreateMap<OrderDetail, BookedCrateDto>()
                    .ForMember(dst => dst.Products, o => o.MapFrom(src => src.SubProducts))
                    .ForMember(dst => dst.CrateDescription, o => o.MapFrom(src => (Crate)src.Item));

                CreateMap<OrderDetailSubProduct, BookedCrateProduct>()
                    .ForMember(dst => dst.Maximum, o => o.MapFrom(src => ((Crate)src.OrderDetail.Item)
                        .Compatibilities
                        .Single(c => c.ProductId == src.ProductId)
                        .Maximum));
            }
        }
    }
}
