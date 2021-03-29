using Musicalog.Data.Models;
using System;
using System.Linq;

namespace Musicalog.Service.Extensions
{
    public static class IQueryableExtensions
    {

        public static IQueryable<T> Sort<T, TKey>(this IQueryable<T> queryable, SortDirection direction, Func<T, TKey> orderFunction) where T : class =>
            direction == SortDirection.Ascending ?
            queryable.OrderBy(orderFunction).AsQueryable() :
            queryable.OrderByDescending(orderFunction).AsQueryable();

    }
}
