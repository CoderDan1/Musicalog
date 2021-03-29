using Musicalog.Data.Models;
using System;
using System.Runtime.Serialization;

namespace Musicalog.Service.Models
{
    [DataContract]
    public class EditAlbumRequestModel
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Stock { get; set; }
        [DataMember]
        public AlbumType AlbumType { get; set; }
        [DataMember]
        public Guid ArtistId { get; set; }
        [DataMember]
        public ArtistListItemModel[] Artists { get; set; }
    }
}