using Musicalog.Web.AlbumService;
using System;
using System.Web.Mvc;

namespace Musicalog.Web.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumService albumService;

        public AlbumsController(IAlbumService albumService)
        {
            this.albumService = albumService;
        }

        [HttpGet]
        public ActionResult List()
        {
            return View(albumService.GetAlbums(1, 10, "", Data.SortDirection.Ascending));
        }

        [HttpGet]
        public ActionResult Details(Guid? id)
        {
            return View(albumService.GetAlbum(id.Value));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateAlbumModel model)
        {
            model.Id = albumService.AddAlbum(model);
            return View();
        }
    }
}