using Musicalog.Data.Models;
using System.Runtime.Serialization;

namespace Musicalog.Service.Models
{
    [DataContract]
    public class AlbumListRequestModel
    {
        [DataMember]
        public int Page { get; set; }
        [DataMember]
        public int PageSize { get; set; }
        [DataMember]
        public string Sort { get; set; }
        [DataMember]
        public SortDirection Direction { get; set; }
        [DataMember]
        public string SuccessMessage { get; set; }
    }
}