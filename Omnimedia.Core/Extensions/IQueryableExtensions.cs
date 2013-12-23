using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Omnimedia.Core.PaginatedList;

namespace Omnimedia.Core.Extensions
{
    public static class IQueryableExtensions
    {
        /// <summary>
        /// Applies the order.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="sortOptions">The sort options.</param>
        /// <returns></returns>
        public static IQueryable<TEntity> ApplyOrder<TEntity>(this IQueryable<TEntity> source, SortOptions sortOptions)
        {
            if (sortOptions.IsValid)
            {
                string methodName = sortOptions.Order == "asc" ? "OrderBy" : "OrderByDescending";
                string[] props = sortOptions.Column.Split('.');
                Type type = typeof(TEntity);
                ParameterExpression arg = Expression.Parameter(type, "x");
                Expression expr = arg;

                foreach (string prop in props)
                {
                    PropertyInfo pi = type.GetProperty(prop);
                    expr = Expression.Property(expr, pi);
                    type = pi.PropertyType;
                }

                Type delegateType = typeof(Func<,>).MakeGenericType(typeof(TEntity), type);
                LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

                object result = typeof(Queryable).GetMethods()
                    .Single(method => method.Name == methodName
                                   && method.IsGenericMethodDefinition
                                   && method.GetGenericArguments().Length == 2
                                   && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(TEntity), type)
                    .Invoke(null, new object[] { source, lambda });

                return (IQueryable<TEntity>)result;
            }

            return source;
        }
    }
}