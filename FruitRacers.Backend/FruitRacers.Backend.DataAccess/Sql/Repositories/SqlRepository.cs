﻿using FruitRacers.Backend.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.DataAccess.Sql.Repositories
{
    public class SqlRepository<T> : ReadOnlySqlRepository<T>, IRepository<T> where T : class
    {
        public SqlRepository(FruitracersContext context) : base(context)
        {

        }

        public virtual void Delete(T entity)
        {
            this.Set.Remove(entity);
        }

        public virtual void Insert(T entity)
        {
            this.Set.Add(entity);
        }

        public virtual void Update(T entity)
        {
            this.Set.Update(entity);
        }
    }
}