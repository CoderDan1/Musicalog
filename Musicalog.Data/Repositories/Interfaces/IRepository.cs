using System;
using System.Linq;
using System.Threading.Tasks;

namespace Musicalog.Data.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> All();
        T GetById(Guid id);
        Task Add(T model);
        Task Remove(Guid id);
    }
}