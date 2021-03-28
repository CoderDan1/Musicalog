namespace Musicalog.Web.Adapters
{
    public interface ICreateAlbumModelAdapter
    {
        Models.CreateAlbumRequestModel FromService(AlbumService.CreateAlbumRequestModel model);
        AlbumService.CreateAlbumRequestModel ToService(Models.CreateAlbumRequestModel model);
    }
}