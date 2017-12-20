﻿using Southwind.Contracts.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Southwind.DataAccess.Repositories
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

        public virtual void Save()
        {
            context.SaveChanges();
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
