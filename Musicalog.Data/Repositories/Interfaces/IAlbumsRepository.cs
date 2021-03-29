using Musicalog.Data.Models;
using System;
using System.Linq;

namespace Musicalog.Data.Repositories.Interfaces
{
    public interface IAlbumsRepository : IRepository<Album>
    {
        IQueryable<Album> GetAllIncludeArtistAndLabel();
        Album GetByIdIncludingArtistAndLabel(Guid id);
    }
}