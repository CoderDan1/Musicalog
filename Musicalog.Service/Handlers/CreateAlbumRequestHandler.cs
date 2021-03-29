using Musicalog.Data.Models;
using Musicalog.Data.Repositories.Interfaces;
using Musicalog.Service.Handlers.Interfaces;
using Musicalog.Service.Models;
using System.Threading.Tasks;

namespace Musicalog.Service.Handlers
{
    public class CreateAlbumRequestHandler : ICreateAlbumRequestHandler
    {
        private readonly IAlbumsRepository albumsRepository;
        private readonly IArtistsRepository artistsRepository;

        public CreateAlbumRequestHandler(
            IAlbumsRepository albumsRepository,
            IArtistsRepository artistsRepository
        )
        {
            this.albumsRepository = albumsRepository;
            this.artistsRepository = artistsRepository;
        }

        public async Task<ActionResultModel> Handle(CreateAlbumRequestModel model)
        {
            var artist = artistsRepository.GetById(model.ArtistId);

            if (artist == null)
                return new ActionResultModel()
                {
                    Success = false,
                    Message = "Artist not found"
                };

            var album = new Album()
            {
                ArtistId = artist.Id,
                Name = model.Name,
                Stock = model.Stock,
                Type = model.AlbumType
            };

            await albumsRepository.AddAsync(album);

            return new ActionResultModel()
            {
                Success = true,
                EntityId = album.Id,
                Message = $"Successfully created album \"{model.Name}\" for {artist.Name}"
            };
        }
    }
}