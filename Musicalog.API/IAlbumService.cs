using Musicalog.API.Models;
using Musicalog.Data;
using System;
using System.ServiceModel;

namespace Musicalog.API
{
    [ServiceContract]
    public interface IAlbumService
    {
        [OperationContract]
        AlbumListModel GetAlbums(int page, int take, string sort, SortDirection direction);

        [OperationContract]
        AlbumDetailsModel GetAlbum(Guid id);

        [OperationContract]
        Guid AddAlbum(CreateAlbumModel model);
    }
}
