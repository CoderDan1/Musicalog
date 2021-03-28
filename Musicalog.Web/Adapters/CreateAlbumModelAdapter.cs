using System.Linq;

namespace Musicalog.Web.Adapters
{
    /// <summary>
    /// You could use automapper or something like that for this
    /// </summary>
    public class CreateAlbumModelAdapter : ICreateAlbumModelAdapter
    {
        public Models.CreateAlbumRequestModel FromService(Services.CreateAlbumRequestModel model) =>
            new Models.CreateAlbumRequestModel()
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

        public Services.CreateAlbumRequestModel ToService(Models.CreateAlbumRequestModel model) =>
            new Services.CreateAlbumRequestModel()
            {
                AlbumType = model.AlbumType,
                ArtistId = model.ArtistId,
                Id = model.Id,
                Name = model.Name,
                Stock = model.Stock
            };
    }
}