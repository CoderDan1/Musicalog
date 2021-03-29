using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musicalog.Data.Models
{
    public class Label : Entity
    {
        [StringLength(250)]
        public string Name { get; set; }
        public ICollection<Artist> Artists { get; set; }
    }
}
