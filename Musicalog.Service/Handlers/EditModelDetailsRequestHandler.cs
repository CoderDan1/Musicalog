using Musicalog.Data.Repositories.Interfaces;
using Musicalog.Service.Handlers.Interfaces;
using Musicalog.Service.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Musicalog.Service.Handlers
{
    public class EditModelDetailsRequestHandler : IEditModelDetailsRequestHandler
    {
        private readonly IAlbumsRepository albumRepository;
        private readonly IArtistsRepository artistRepository;

        public EditModelDetailsRequestHandler(
            IAlbumsRepository albumRepository,
            IArtistsRepository artistRepository
        )
        {
            this.albumRepository = albumRepository;
            this.artistRepository = artistRepository;
        }

        public Task<EditAlbumRequestModel> Handle(EditModelDetailsRequest request)
        {
            var album = albumRepository.GetById(request.Id);
            var artists = artistRepository.All().OrderBy(x => x.Name).ToList();

            return Task.FromResult(new EditAlbumRequestModel()
            {
                AlbumType = album.Type,
                ArtistId = album.ArtistId,
                Artists = artists.Select(x => new ArtistListItemModel()
                {
                    Name = x.Name,
                    Id = x.Id
                }).ToArray(),
                Name = album.Name,
                Id = album.Id,
                Stock = album.Stock
            });
        }
    }
}