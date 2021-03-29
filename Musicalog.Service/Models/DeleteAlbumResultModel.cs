using System.Runtime.Serialization;

namespace Musicalog.Service.Models
{
    [DataContract]
    public class DeleteAlbumResultModel
    {
        [DataMember]
        public string Message { get; set; }
    }
}