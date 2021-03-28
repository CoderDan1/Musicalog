using Musicalog.Data.Models;
using Musicalog.Service.Models;

namespace Musicalog.Service
{
    public interface IAlbumMapper
    {
        AlbumDetailsModel ToDetailModel(Album album);

        AlbumListItemModel ToListModel(Album album);
    }
}
