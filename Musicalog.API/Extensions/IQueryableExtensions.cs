using Musicalog.Data;
using System.Linq;

namespace Musicalog.API.Extensions
{
    public static class IQueryableExtensions
    {

        private static object OrderByPredicate<T>(T x, string sort) => x.GetType().GetProperty(sort).GetValue(x, null);

        public static IQueryable<T> Sort<T>(this IQueryable<T> queryable, string sort, SortDirection direction) where T : class =>
            direction == SortDirection.Ascending ?
            queryable.OrderBy(x => OrderByPredicate(x, sort)) :
            queryable.OrderByDescending(x => OrderByPredicate(x, sort));

    }
}
