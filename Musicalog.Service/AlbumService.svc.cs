using Musicalog.Data.Models;
using Musicalog.Data.Repositories.Interfaces;
using Musicalog.Service.Handlers.Interfaces;
using Musicalog.Service.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Musicalog.Service
{
    public class AlbumService : IAlbumService
    {
        private readonly IArtistsRepository artistRepository;
        private readonly IAlbumDetailsRequestHandler albumDetailsRequestHandler;
        private readonly IDeleteAlbumRequestHandler deleteAlbumRequestHandler;
        private readonly IListAlbumsRequestHandler listAlbumsRequestHandler;
        private readonly ICreateAlbumRequestHandler createAlbumRequestHandler;

        public AlbumService(
            IArtistsRepository artistRepository,
            IAlbumDetailsRequestHandler albumDetailsRequestHandler,
            IDeleteAlbumRequestHandler deleteAlbumRequestHandler,
            IListAlbumsRequestHandler listAlbumsRequestHandler,
            ICreateAlbumRequestHandler createAlbumRequestHandler
        )
        {
            this.artistRepository = artistRepository;
            this.albumDetailsRequestHandler = albumDetailsRequestHandler;
            this.deleteAlbumRequestHandler = deleteAlbumRequestHandler;
            this.listAlbumsRequestHandler = listAlbumsRequestHandler;
            this.createAlbumRequestHandler = createAlbumRequestHandler;
        }

        public Task<CreateAlbumResultModel> CreateAsync(CreateAlbumRequestModel model) =>
            createAlbumRequestHandler.Handle(model);

        public Task<AlbumDetailsResultModel> GetDetailsAsync(Guid id) =>
            albumDetailsRequestHandler.Handle(new AlbumDetailsRequestModel() { Id = id });

        public Task<DeleteAlbumResultModel> DeleteAsync(Guid id) =>
            deleteAlbumRequestHandler.Handle(new DeleteAlbumRequestModel() { Id = id });

        public Task<AlbumListResultModel> ListAsync(AlbumListRequestModel request) =>
            listAlbumsRequestHandler.Handle(request);

        public CreateAlbumRequestModel GetDefaultCreateModel() => new CreateAlbumRequestModel()
        {
            AlbumType = AlbumType.CD,
            ArtistId = Guid.Empty,
            Artists = artistRepository.All().OrderBy(x => x.Name)
                .Select(x => new ArtistListItemModel()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToArray(),
            Name = string.Empty,
            Stock = 0
        };
    }
}
