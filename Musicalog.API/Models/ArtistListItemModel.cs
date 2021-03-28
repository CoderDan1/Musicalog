using System;
using System.Runtime.Serialization;

namespace Musicalog.API.Models
{
    [DataContract]
    public class ArtistListItemModel
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Guid Id { get; set; }
    }
}
