using Musicalog.Data.Models;
using Musicalog.Data.Repositories.Interfaces;
using Musicalog.Service.Extensions;
using Musicalog.Service.Handlers.Interfaces;
using Musicalog.Service.Models;
using PagedList;
using System.Linq;
using System.Threading.Tasks;

namespace Musicalog.Service.Handlers
{
    public class ListAlbumsRequestHandler : IListAlbumsRequestHandler
    {
        private IAlbumsRepository repository;

        public ListAlbumsRequestHandler(IAlbumsRepository repository)
        {
            this.repository = repository;
        }

        public Task<AlbumListResultModel> Handle(AlbumListRequestModel request)
        {
            var albums = repository.GetAllIncludeArtistAndLabel()
                .OrderBy(x => x.Artist.Name);

            var sorted = string.IsNullOrWhiteSpace(request.Sort) ? albums : GetSorted(request.Sort, request.Direction, albums);

            var pagedList = sorted.Select(x => new AlbumListItemModel()
            {
                Id = x.Id,
                Artist = x.Artist.Name,
                Name = x.Name,
                Stock = x.Stock,
                Type = x.Type == AlbumType.CD ? "CD" : "Vinyl"
            }).ToPagedList(request.Page, request.PageSize);

            return Task.FromResult(new AlbumListResultModel
            {
                Albums = (PagedList<AlbumListItemModel>)pagedList,
                Page = request.Page,
                PageSize = request.PageSize,
                Sort = request.Sort,
                SortDirection = request.Direction
            });
        }

        private IQueryable<Album> GetSorted(string sort, SortDirection direction, IQueryable<Album> albums)
        {
            switch (sort)
            {
                default:
                case "":
                case nameof(Album.Artist):
                    return albums.Sort(direction, x => x.Artist.Name);
                case nameof(Album.Stock):
                    return albums.Sort(direction, x => x.Stock);
                case nameof(Album.Type):
                    return albums.Sort(direction, x => x.Type);
                case nameof(Album.Name):
                    return albums.Sort(direction, x => x.Name);
            }
        }
    }
}