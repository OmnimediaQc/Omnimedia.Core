using System;
using System.Linq.Expressions;

namespace Omnimedia.Core.Utilities
{
    public static class ExpressionUtilities
    {
        /// <summary>
        /// Create expression for .Where(entity => entity.Id == 'id')
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> GetExpression<T>(object id, string keyProperty)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "entity");
            MemberExpression property = Expression.Property(parameter, keyProperty);
            var equalsTo = Expression.Constant(id);
            var equality = Expression.Equal(property, equalsTo);

            return Expression.Lambda<Func<T, bool>>(equality, new[] { parameter });
        }
    }
}