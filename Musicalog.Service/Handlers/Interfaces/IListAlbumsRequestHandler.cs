using Musicalog.Service.Models;

namespace Musicalog.Service.Handlers.Interfaces
{
    public interface IListAlbumsRequestHandler : IRequestHandler<AlbumListRequestModel, AlbumListResultModel>
    {
    }
}