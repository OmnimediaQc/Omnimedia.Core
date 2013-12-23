using System;
using System.Linq;
using System.Linq.Expressions;

namespace Omnimedia.Core.DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Gets a list of entities.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        /// <summary>
        /// Gets the entity by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        T GetById(int id);

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        T Insert(T entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        T Update(T entity);

        /// <summary>
        /// Deletes the specified entity by id.
        /// </summary>
        /// <param name="id">The id.</param>
        void Delete(int id);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);

        /// <summary>
        /// Clones an entity.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="keyProperty">The key property.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        T Clone(object id, string keyProperty, string includeProperties = "");
    }
}