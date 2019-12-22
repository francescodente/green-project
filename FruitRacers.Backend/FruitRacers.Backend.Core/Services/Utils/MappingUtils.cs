using AutoMapper;
using FruitRacers.Backend.Contracts.Addresses;
using FruitRacers.Backend.Contracts.Categories;
using FruitRacers.Backend.Contracts.Orders;
using FruitRacers.Backend.Contracts.Products;
using FruitRacers.Backend.Contracts.TimeSlots;
using FruitRacers.Backend.Contracts.Users;
using FruitRacers.Backend.Contracts.Users.Roles;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Entities.Extensions;
using FruitRacers.Backend.Shared.Utils;
using System.Collections.Generic;
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
                this.CreateMap<Address, AddressOutputDto>();
            }
        }

        private class OrderMapping : Profile
        {
            public OrderMapping()
            {
                this.CreateMap<Order, CartOutputDto>()
                    .ForMember(dst => dst.DeliveryInfo, o => o.MapFrom((src, dst, m, context) => context.Mapper.Map<DeliveryInfoOutputDto>(src)))
                    .ForMember(dst => dst.Details, o => o.MapFrom((src, dst, m, context) => this.CreateCartDetailsList(src, context)));

                this.CreateMap<Order, DeliveryInfoOutputDto>();

                this.CreateMap<OrderDetail, CartItemOutputDto>();
            }

            private IEnumerable<SupplierOrderSectionDto<CartItemOutputDto>> CreateCartDetailsList(Order cart, IMapper mapper)
            {
                return cart.OrderDetails
                    .GroupBy(
                        d => d.Product.SupplierId,
                        (_, details) => new SupplierOrderSectionDto<CartItemOutputDto>
                        {
                            Items = details.Select(mapper.Map<CartItemOutputDto>),
                            Supplier = mapper.Map<SupplierDto>(details.First().Product.Supplier) // TODO: change to different type (e.g. SupplierInfoDto)
                        });
            }
        }

        private class ProductMapping : Profile
        {
            public ProductMapping()
            {
                this.CreateMap<Price, PriceDto>();

                this.CreateMap<Product, ProductOutputDto>()
                    .ForMember(dst => dst.Categories, o => o.MapFrom(src => src.ProductCategories.Select(c => c.Category)))
                    .ForMember(dst => dst.Prices, o => o.MapFrom((src, dst, m, context) => this.CreatePriceDictionary(src, context)));
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
                this.CreateMap<Person, PersonDto>();

                this.CreateMap<CustomerBusiness, CustomerBusinessDto>();

                this.CreateMap<Supplier, SupplierDto>()
                    .ForMember(dst => dst.Address, o => o.MapFrom(src => src.User.Addresses.SingleOrDefault()));

                this.CreateMap<Administrator, AdministratorDto>();

                this.CreateMap<DeliveryCompany, DeliveryCompanyDto>();

                this.CreateMap<User, UserOutputDto>()
                    .ForMember(dst => dst.Roles, o => o.MapFrom(src => src.GetRoleTypes()))
                    .ForMember(dst => dst.RolesData, o => o.MapFrom((src, dst, m, context) => this.CreateRoleDictionary(src, context)));
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
                this.CreateMap<Category, CategoryDto>()
                    .ForMember(dst => dst.ImageUrl, o => o.MapFrom(src => src.Image.Path));
            }
        }

        private class TimeSlotMapping : Profile
        {
            public TimeSlotMapping()
            {
                this.CreateMap<TimeSlot, TimeSlotDto>();

                this.CreateMap<TimeSlot, TimeSlotWithCapacityDto>();
            }
        }
    }
}
