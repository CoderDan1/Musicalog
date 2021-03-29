using Musicalog.Data.Models;
using Musicalog.Service.Models;
using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Musicalog.Service
{
    [ServiceContract]
    public interface IAlbumService
    {
        [OperationContract]
        Task<CreateAlbumResultModel> CreateAsync(CreateAlbumRequestModel model);

        [OperationContract]
        Task<AlbumDetailsResultModel> GetDetailsAsync(Guid id);

        [OperationContract]
        Task<DeleteAlbumResultModel> DeleteAsync(Guid id);

        [OperationContract]
        Task<AlbumListResultModel> ListAsync(AlbumListRequestModel request);

        [OperationContract]
        CreateAlbumRequestModel GetDefaultCreateModel();
    }
}
