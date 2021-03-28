using Musicalog.Web.Adapters;
using Musicalog.Web.AlbumService;
using Ninject.Modules;

namespace Musicalog.Web.Modules
{
    public class AlbumModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAlbumService>()
                .To<AlbumServiceClient>()
                .InTransientScope();

            Bind<ICreateAlbumModelAdapter>()
                .To<CreateAlbumModelAdapter>()
                .InSingletonScope();
        }
    }
}
