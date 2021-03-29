using Musicalog.Data.Repositories.Interfaces;
using Musicalog.Service.Handlers.Interfaces;
using Musicalog.Service.Models;
using System.Threading.Tasks;

namespace Musicalog.Service.Handlers
{
    public class EditAlbumRequestHandler : IEditAlbumRequestHandler
    {
        private readonly IAlbumsRepository repository;

        public EditAlbumRequestHandler(
            IAlbumsRepository repository
        )
        {
            this.repository = repository;
        }

        public async Task<ActionResultModel> Handle(EditAlbumRequestModel request)
        {
            var album = repository.GetById(request.Id);
            album.Name = request.Name;
            album.Stock = request.Stock;
            album.Type = request.AlbumType;
            album.ArtistId = request.ArtistId;

            await repository.SaveChangesAsync();

            return new ActionResultModel()
            {
                Success = true,
                Message = $"Successfully updated Album \"{request.Name}\""
            };
        }
    }
}