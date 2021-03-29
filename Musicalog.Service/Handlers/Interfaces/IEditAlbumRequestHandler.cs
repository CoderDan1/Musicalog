using Musicalog.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musicalog.Service.Handlers.Interfaces
{
    public interface IEditAlbumRequestHandler : IRequestHandler<EditAlbumRequestModel, ActionResultModel>
    {
    }
}