using Musicalog.Data.Models;
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
        public int Page { get; set; } = 1;
        [DataMember]
        public int PageSize { get; set; } = 10;
        [DataMember]
        public string Sort { get; set; } = nameof(Album.Name);
        [DataMember]
        public SortDirection SortDirection { get; set; } = SortDirection.Descending;
        [DataMember]
        public string SuccessMessage { get; set; }
    }
}
