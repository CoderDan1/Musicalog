using Musicalog.API.Models;
using Musicalog.Data.Models;

namespace Musicalog.API
{
    public interface IAlbumMapper
    {
        AlbumDetailsModel ToDetailModel(Album album);

        AlbumListItemModel ToListModel(Album album);
    }
}
