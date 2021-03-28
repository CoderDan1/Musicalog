using System;
using System.Collections.Generic;

namespace Musicalog.Data.Models
{
    public class Label
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Artist> Artists { get; set; }
    }
}
