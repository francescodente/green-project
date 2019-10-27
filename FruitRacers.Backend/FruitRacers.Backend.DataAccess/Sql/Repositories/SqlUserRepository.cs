using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FruitRacers.Backend.DataAccess.Sql.Repositories
{
    public class SqlUserRepository : SqlRepository<User>, IUserRepository
    {
        public SqlUserRepository(FruitracersContext context)
            : base(context)
        {
        }

        public IUserRepository CustomerBusinessesOnly()
        {
            this.ChainQueryModification(q => q
                .Include(u => u.UserBusiness)
                    .ThenInclude(u => u.UserBusinessCustomer)
                .Where(u => u.UserBusiness.UserBusinessCustomer != null));
            return this;
        }

        public IUserRepository IncludingRoles()
        {
            this.ChainQueryModification(q => q
                .Include(u => u.UserPerson)
                .Include(u => u.UserBusiness)
                    .ThenInclude(u => new { u.UserBusinessCustomer, u.UserBusinessSupplier }));
            return this;
        }

        public IUserRepository PeopleOnly()
        {
            throw new NotImplementedException();
        }

        public IUserRepository SupplierBusinessesOnly()
        {
            this.ChainQueryModification(q => q
                .Include(u => u.UserBusiness)
                    .ThenInclude(u => u.UserBusinessSupplier)
                .Where(u => u.UserBusiness.UserBusinessSupplier != null));
            return this;
        }
    }
}
