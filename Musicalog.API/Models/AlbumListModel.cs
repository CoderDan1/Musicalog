using Musicalog.Data;
using PagedList;
using System.Runtime.Serialization;

namespace Musicalog.API.Models
{
    [DataContract]
    public class AlbumListModel
    {
        [DataMember]
        public PagedList<AlbumListItemModel> Albums { get; set; }
        [DataMember]
        public int Page { get; set; }
        [DataMember]
        public int PageSize { get; set; }
        [DataMember]
        public string Sort { get; set; }
        [DataMember]
        public SortDirection SortDirection { get; set; }
    }
}
