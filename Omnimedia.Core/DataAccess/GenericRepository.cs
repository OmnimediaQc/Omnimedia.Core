using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Omnimedia.Core.DataAccess.Interfaces;
using Omnimedia.Core.Utilities;

namespace Omnimedia.Core.DataAccess
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal DbContext _context;
        internal DbSet<T> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository&lt;TEntity&gt;"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        /// <summary>
        /// Gets a list of entities.
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(property);

            if (orderBy != null)
                return orderBy(query);

            return query;
        }

        /// <summary>
        /// Gets the entity by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual T Insert(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual T Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        /// <summary>
        /// Deletes the specified entity by id.
        /// </summary>
        /// <param name="id">The id.</param>
        public virtual void Delete(int id)
        {
            T entity = GetById(id);
            Delete(entity);
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);

            _dbSet.Remove(entity);
        }

        /// <summary>
        /// Clones an entity.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="keyProperty">The key property.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        public virtual T Clone(object id, string keyProperty, string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(property);

            T clone = query.AsNoTracking<T>()
                .FirstOrDefault(ExpressionUtilities.GetExpression<T>(id, keyProperty));

            _dbSet.Add(clone);
            return clone;
        }
    }
}