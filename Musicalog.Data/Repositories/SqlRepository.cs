using Musicalog.Data.Models;
using Musicalog.Data.Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Musicalog.Data.Repositories
{
    public abstract class SqlRepository<T> : IRepository<T>
        where T : Entity
    {
        public readonly AlbumsContext Context;

        public SqlRepository(
            AlbumsContext context
        )
        {
            Context = context;
        }

        public IQueryable<T> All() => Context.Set<T>().AsQueryable();

        public T GetById(Guid id) => Context.Set<T>().Find(id);

        public Task AddAsync(T model)
        {
            Context.Set<T>().Add(model);
            return Context.SaveChangesAsync();
        }

        public Task RemoveAsync(Guid id)
        {
            var model = GetById(id);
            Context.Set<T>().Remove(model);
            return Context.SaveChangesAsync();
        }

        public Task SaveChangesAsync() => Context.SaveChangesAsync();
    }
}
