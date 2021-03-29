using Musicalog.Data.Models;
using Musicalog.Data.Repositories.Interfaces;
using Musicalog.Service.Handlers.Interfaces;
using Musicalog.Service.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Musicalog.Service.Handlers
{
    public class AlbumDetailsRequestHandler : IAlbumDetailsRequestHandler
    {
        private readonly IAlbumsRepository repository;

        public AlbumDetailsRequestHandler(IAlbumsRepository repository)
        {
            this.repository = repository;
        }

        public Task<AlbumDetailsResultModel> Handle(AlbumDetailsRequestModel request)
        {
            var result = repository.GetAllIncludeArtistAndLabel().Single(x => x.Id == request.Id);

            return Task.FromResult(new AlbumDetailsResultModel
            {
                Artist = result.Artist.Name,
                Label = result.Artist.Label.Name,
                Id = result.Id,
                Name = result.Name,
                Stock = result.Stock,
                Type = result.Type == AlbumType.CD ? "CD" : "Vinyl"
            });
        }
    }
}