using Musicalog.Data.Models;
using Musicalog.Service.Models;
using System;
using System.ServiceModel;

namespace Musicalog.Service
{
    [ServiceContract]
    public interface IAlbumService
    {
        [OperationContract]
        AlbumListModel GetAllPagedAndSorted(int page, int take, string sort, SortDirection direction);

        [OperationContract]
        AlbumDetailsModel GetById(Guid id);

        [OperationContract]
        CreateAlbumResultModel Create(CreateAlbumRequestModel model);

        [OperationContract]
        CreateAlbumRequestModel GetDefaultCreateModel();

        [OperationContract]
        DeleteAlbumResultModel Delete(Guid albumId);
    }
}
