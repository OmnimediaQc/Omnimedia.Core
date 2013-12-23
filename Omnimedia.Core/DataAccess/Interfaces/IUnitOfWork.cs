using System.Collections.Generic;

namespace Omnimedia.Core.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Returns an instance of a GenericRepository.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        IGenericRepository<T> Repository<T>() where T : class;

        /// <summary>
        /// Creates the repository of specified type.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        void CreateRepository<T>() where T : class;

        /// <summary>
        /// Gets the repository of specified type.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        IGenericRepository<T> GetRepository<T>() where T : class;

        /// <summary>
        /// Checks whether a repository of specified type already exists.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        bool RepositoryExists<T>() where T : class;

        /// <summary>
        /// Saves the DatabaseContext.
        /// </summary>
        void Save();

        /// <summary>
        /// Wrapper to expose the SqlQuery method from DbContext.Database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        IEnumerable<T> SqlQuery<T>(string sql, params object[] parameters);

        /// <summary>
        /// Get a scalar value from SqlQuery method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        T SqlScalar<T>(string sql, params object[] parameters);

        /// <summary>
        /// Wrapper to expose the ExecuteSqlCommand method from DbContext.Database.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        int ExecuteSqlCommand(string sql, params object[] parameters);
    }
}