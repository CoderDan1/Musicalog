using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Musicalog.Data
{
    public class Artist
    {
        [Key]
        public Guid Id { get; set; }
        public Guid LabelId { get; set; }
        public string Name { get; set; }
        public Label Label { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}
