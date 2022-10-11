using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mm.DataAccessLayer
{
    public interface IGenericDataRepository<T> where T : class, IEntity
    {
        /* the return type of the two Get* methods is IList<T> rather than IQueryable<T>. 
         * This means that the methods will be returning the actual already executed results 
         * from the queries rather than executable queries themselves.
         */
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);

        /* Each of the methods for reading data from the database in the concrete sample 
         * implementation of the IGenericDataRepository<T> interface below supports eager 
         * loading by accepting a variable number of navigation properties to be included in the query as arguments.
         */
        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);

        void Add(params T[] items);
        void Update(params T[] items);
        void Remove(params T[] items);
    }
}
