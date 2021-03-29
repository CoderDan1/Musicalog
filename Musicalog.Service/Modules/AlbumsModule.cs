using Musicalog.Data;
using Musicalog.Data.Repositories;
using Musicalog.Data.Repositories.Interfaces;
using Musicalog.Service.Handlers;
using Musicalog.Service.Handlers.Interfaces;
using Ninject.Modules;

namespace Musicalog.Service.Modules
{
    public class AlbumsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<AlbumsContext>().ToSelf();
            Bind<IAlbumsRepository>().To<AlbumsRepository>().InTransientScope();
            Bind<IArtistsRepository>().To<ArtistsRepository>().InTransientScope();
            Bind<ILabelsRepository>().To<LabelsRepository>().InTransientScope();
            Bind<ICreateAlbumRequestHandler>().To<CreateAlbumRequestHandler>();
            Bind<IDeleteAlbumRequestHandler>().To<DeleteAlbumRequestHandler>();
            Bind<IListAlbumsRequestHandler>().To<ListAlbumsRequestHandler>();
            Bind<IAlbumDetailsRequestHandler>().To<AlbumDetailsRequestHandler>();
        }
    }
}