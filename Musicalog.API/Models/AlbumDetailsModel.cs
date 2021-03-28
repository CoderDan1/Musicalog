using System;
using System.Runtime.Serialization;

namespace Musicalog.API.Models
{
    [DataContract]
    public class AlbumDetailsModel
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Artist { get; set; }
        [DataMember]
        public string Label { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public int Stock { get; set; }
    }
}
