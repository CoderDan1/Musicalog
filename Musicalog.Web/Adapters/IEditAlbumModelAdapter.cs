using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musicalog.Web.Adapters
{
    public interface IEditAlbumModelAdapter
    {
        Models.EditAlbumRequestModel FromService(Services.EditAlbumRequestModel model);
        Services.EditAlbumRequestModel ToService(Models.EditAlbumRequestModel model);
    }
}