using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Omnimedia.Core.DataAccess.Interfaces;

namespace Omnimedia.Core.DataAccess
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public DbContext Context { get; set; }
        private List<object> _instances = new List<object>();

        public UnitOfWork(DbContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Returns an instance of a GenericRepository.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (!RepositoryExists<T>())
                CreateRepository<T>();

            return GetRepository<T>();
        }

        /// <summary>
        /// Creates the repository of specified type.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        public void CreateRepository<T>() where T : class
        {
            _instances.Add(
                new GenericRepository<T>(this.Context)
            );
        }

        /// <summary>
        /// Gets the repository of specified type.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            return (GenericRepository<T>)_instances
                .Single(i => i.GetType() == typeof(GenericRepository<T>));
        }

        /// <summary>
        /// Checks whether a repository of specified type already exists.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public bool RepositoryExists<T>() where T : class
        {
            return _instances.Any(i => i.GetType() == typeof(GenericRepository<T>));
        }

        /// <summary>
        /// Saves the DatabaseContext.
        /// </summary>
        public void Save()
        {
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Wrapper to expose the SqlQuery method from DbContext.Database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public IEnumerable<T> SqlQuery<T>(string sql, params object[] parameters)
        {
            return this.Context.Database.SqlQuery<T>(sql, parameters);
        }

        /// <summary>
        /// Get a scalar value from SqlQuery method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public T SqlScalar<T>(string sql, params object[] parameters)
        {
            return this.SqlQuery<T>(sql, parameters).FirstOrDefault();
        }

        /// <summary>
        /// Wrapper to expose the ExecuteSqlCommand method from DbContext.Database.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return this.Context.Database.ExecuteSqlCommand(sql, parameters);
        }

        private bool Disposed = false;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.Disposed)
                if (disposing)
                    this.Context.Dispose();

            this.Disposed = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}