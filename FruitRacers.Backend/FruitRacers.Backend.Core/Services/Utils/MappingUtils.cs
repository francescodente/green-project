using AutoMapper;
using FruitRacers.Backend.Contracts.Addresses;
using FruitRacers.Backend.Contracts.Categories;
using FruitRacers.Backend.Contracts.Orders;
using FruitRacers.Backend.Contracts.TimeSlots;
using FruitRacers.Backend.Contracts.Users;
using FruitRacers.Backend.Contracts.Users.Roles;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Entities.Extensions;
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
                this.CreateMap<Order, DeliveryInfoOutputDto>();

                this.CreateMap<OrderDetail, CartItemOutputDto>();

                this.CreateMap<Order, CartOutputDto>()
                    .ForMember(dst => dst.DeliveryInfo, o => o.MapFrom(src => src));

                this.CreateMap<OrderDetail, OrderDetailDto>();

                this.CreateMap<Order, OrderDto>()
                    .ForMember(dst => dst.DeliveryInfo, o => o.MapFrom(src => src));
            }
        }

        private class ProductMapping : Profile
        {
            public ProductMapping()
            {
                
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
                    .ForMember(dst => dst.RoleNames, o => o.MapFrom(src => src.GetRoleTypes()))
                    .ForMember(dst => dst.RolesData, o => o.MapFrom((src, dst, _, context) => this.CreateRoleDictionary(src, context)));
            }

            private IDictionary<RoleTypeDto, RoleDto> CreateRoleDictionary(User source, ResolutionContext context)
            {
                IMapper mapper = context.Mapper;
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
    }
}
