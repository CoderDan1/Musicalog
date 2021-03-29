using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musicalog.Data.Models
{
    public class Artist : Entity
    {
        [ForeignKey(nameof(Label))]
        public Guid LabelId { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        public Label Label { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}
