using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Exceptions
{
    public class CategoryNotFoundException : DomainException
    {
        public CategoryNotFoundException(int categoryId)
            : base(string.Format("Unable to find time slot with id {0}", categoryId))
        {
        }
    }
}
