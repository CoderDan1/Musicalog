namespace Musicalog.Web.Adapters
{
    public interface ICreateAlbumModelAdapter
    {
        Models.CreateAlbumRequestModel FromService(Services.CreateAlbumRequestModel model);
        Services.CreateAlbumRequestModel ToService(Models.CreateAlbumRequestModel model);
    }
}