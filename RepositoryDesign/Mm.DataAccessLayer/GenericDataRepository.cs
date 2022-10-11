using DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Mm.DataAccessLayer
{
    public class GenericDataRepository<T> : IGenericDataRepository<T> where T : class, IEntity
    {
        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            using (var context = new Entities())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .ToList<T>();
            }
            return list;
        }

        public virtual IList<T> GetList(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            using (var context = new Entities())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .Where(where)
                    .ToList<T>();
            }
            return list;
        }

        public virtual T GetSingle(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;
            using (var context = new Entities())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                item = dbQuery
                    .AsNoTracking() //Don't track any changes for the selected item
                    .FirstOrDefault(where); //Apply where clause
            }
            return item;
        }

        public virtual void Add(params T[] items)
        {
            Update(items);
        }

        public virtual void Update(params T[] items)
        {
            using (var context = new Entities())
            {
                DbSet<T> dbSet = context.Set<T>();
                foreach (T item in items)
                {
                    dbSet.Add(item);
                    foreach (DbEntityEntry<IEntity> entry in context.ChangeTracker.Entries<IEntity>())
                    {
                        IEntity entity = entry.Entity;
                        entry.State = GetEntityState(entity.EntityState);
                    }
                }
                context.SaveChanges();
            }
        }

        public virtual void Remove(params T[] items)
        {
            Update(items);
        }

        protected static System.Data.EntityState GetEntityState(DomainModel.EntityState entityState)
        {
            switch (entityState)
            {
                case DomainModel.EntityState.Unchanged:
                    return System.Data.EntityState.Unchanged;
                case DomainModel.EntityState.Added:
                    return System.Data.EntityState.Added;
                case DomainModel.EntityState.Modified:
                    return System.Data.EntityState.Modified;
                case DomainModel.EntityState.Deleted:
                    return System.Data.EntityState.Deleted;
                default:
                    return System.Data.EntityState.Detached;
            }
        }
    }
}
