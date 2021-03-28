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
        AlbumListModel GetAllPagedAndSorted(int page, int take, string sort, SortDirection direction);

        [OperationContract]
        AlbumDetailsModel GetById(Guid id);

        [OperationContract]
        CreateAlbumResultModel Create(CreateAlbumRequestModel model);

        [OperationContract]
        CreateAlbumRequestModel GetDefaultCreateModel();
    }
}
