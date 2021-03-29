using Musicalog.Data.Models;
using Musicalog.Data.Repositories.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;

namespace Musicalog.Data.Repositories
{
    public class AlbumsRepository : SqlRepository<Album>, IAlbumsRepository
    {
        public AlbumsRepository(AlbumsContext context) : base(context)
        { }

        public IQueryable<Album> GetAllIncludeArtistAndLabel() =>
            Context.Albums.Include(x => x.Artist.Label);

        public Album GetByIdIncludingArtistAndLabel(Guid id) =>
            GetAllIncludeArtistAndLabel().Single(x => x.Id == id);
    }
}