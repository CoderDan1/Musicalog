using Musicalog.Data.Models;
using System.Data.Entity;

namespace Musicalog.Data
{
    public class AlbumsContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Label> Labels { get; set; }
        public AlbumsContext() : base(nameof(AlbumsContext))
        { }
    }
}
