using Musicalog.Web.Adapters;
using Musicalog.Web.Services;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Musicalog.Web.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumService albumService;
        private readonly ICreateAlbumModelAdapter createModelAdapter;

        public AlbumsController(
            IAlbumService albumService,
            ICreateAlbumModelAdapter createModelAdapter
        )
        {
            this.albumService = albumService;
            this.createModelAdapter = createModelAdapter;
        }

        [HttpGet]
        public async Task<ActionResult> List(AlbumListModel request)
        {
            var safePage = request.Page < 1 ? 1 : request.Page;
            var safePageSize = request.PageSize < 1 ? 10 : request.PageSize;
            var model = await albumService.GetAllPagedAndSortedAsync(safePage, safePageSize, request.Sort, request.SortDirection);
            model.SuccessMessage = request.SuccessMessage;
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Details(Guid? id)
        {
            return View(await albumService.GetByIdAsync(id.Value));
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var serviceModel = await albumService.GetDefaultCreateModelAsync();
            var model = createModelAdapter.FromService(serviceModel);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Models.CreateAlbumRequestModel model)
        {
            var result = await albumService.CreateAsync(createModelAdapter.ToService(model));

            return RedirectToAction("List", new AlbumListModel()
            {
                SuccessMessage = result.Message
            });
        }
    }
}