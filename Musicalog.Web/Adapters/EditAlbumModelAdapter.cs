using System.Linq;

namespace Musicalog.Web.Adapters
{
    public class EditAlbumModelAdapter : IEditAlbumModelAdapter
    {
        public Models.EditAlbumRequestModel FromService(Services.EditAlbumRequestModel model) =>
            new Models.EditAlbumRequestModel()
            {
                AlbumType = model.AlbumType,
                ArtistId = model.ArtistId,
                Items = model.Artists.Select(x => new System.Web.Mvc.SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                    Selected = false
                }).ToList(),
                Id = model.Id,
                Name = model.Name,
                Stock = model.Stock
            };

        public Services.EditAlbumRequestModel ToService(Models.EditAlbumRequestModel model) =>
            new Services.EditAlbumRequestModel()
            {
                AlbumType = model.AlbumType,
                ArtistId = model.ArtistId,
                Id = model.Id,
                Name = model.Name,
                Stock = model.Stock
            };
    }
}