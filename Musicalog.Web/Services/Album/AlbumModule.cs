using Musicalog.Web.AlbumService;
using Ninject.Modules;

namespace Musicalog.Web.Core.Services.Album
{
    public class AlbumModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAlbumService>()
                .To<AlbumServiceClient>()
                .InTransientScope();
        }
    }
}
