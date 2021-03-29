using Musicalog.Data;
using Musicalog.Data.Models;
using Musicalog.Data.Repositories;
using Musicalog.Data.Repositories.Interfaces;
using System;

namespace Musicalog.Data.Repositories
{
    public class ArtistsRepository : SqlRepository<Artist>, IArtistsRepository
    {
        public ArtistsRepository(AlbumsContext context) : base(context)
        {
        }
    }
}