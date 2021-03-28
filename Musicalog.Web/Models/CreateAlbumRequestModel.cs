using System.Collections.Generic;
using System.Web.Mvc;

namespace Musicalog.Web.Models
{
    public class CreateAlbumRequestModel : AlbumService.CreateAlbumRequestModel
    {
        public IReadOnlyCollection<SelectListItem> Items { get; set; }
    }
}