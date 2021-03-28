using System;
using System.Collections.Generic;

namespace Musicalog.Data
{
    public class Label
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Artist> Artists { get; set; }
    }
}
