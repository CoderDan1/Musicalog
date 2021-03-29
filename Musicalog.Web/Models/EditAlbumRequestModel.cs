using System.Collections.Generic;
using System.Web.Mvc;

namespace Musicalog.Web.Models
{
    public class EditAlbumRequestModel : Services.EditAlbumRequestModel
    {
        public IReadOnlyCollection<SelectListItem> Items { get; set; }
    }
}