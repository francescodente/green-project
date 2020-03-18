using FruitRacers.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FruitRacers.Backend.Core.Repositories
{
    public interface ISectionRepository : IReadOnlyRepository<OrderSection>
    {
        ISectionRepository WithState(OrderSectionState state);
    }
}
