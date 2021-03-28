using System;
using System.ComponentModel.DataAnnotations;

namespace Musicalog.Data.Models
{
    public class Album
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ArtistId { get; set; }
        public string Name { get; set; }
        public AlbumType Type { get; set; }
        public Artist Artist { get; set; }
        public int Stock { get; set; }
    }
}
