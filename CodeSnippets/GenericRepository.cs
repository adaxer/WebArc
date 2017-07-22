﻿using Southwind.Interfaces;
using Southwind.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Southwind.DataAccess
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        DbContext context;

        public GenericRepository(DbContext uow)
        {
            context = uow;// as ISouthwindDb;
        }

        public virtual void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public virtual IQueryable<T> Find(Expression<Func<T, bool>> filter=null)
        {
            if (filter == null)
                return context.Set<T>();
            else 
                return context.Set<T>().Where(filter);
        }
    }


}
