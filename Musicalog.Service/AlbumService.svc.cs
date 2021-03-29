using Musicalog.Data;
using Musicalog.Data.Models;
using Musicalog.Service.Extensions;
using Musicalog.Service.Models;
using PagedList;
using System;
using System.Linq;
using System.Data.Entity;

namespace Musicalog.Service
{
    public class AlbumService : IAlbumService
    {
        private readonly AlbumsContext context;

        public AlbumService(
            AlbumsContext context
        )
        {
            this.context = context;
        }

        public CreateAlbumResultModel Create(CreateAlbumRequestModel model) 
        {
            context.Albums.Add(new Album()
            {
                ArtistId = model.ArtistId,
                Name = model.Name,
                Stock = model.Stock,
                Type = model.AlbumType
            });
            
            context.SaveChanges();

            return new CreateAlbumResultModel()
            {
                Success = true,
                Message = $"Successfully created album \"{model.Name}\" for {context.Artists.Single(x => x.Id == model.ArtistId).Name}"
            };
        }

        public AlbumDetailsModel GetById(Guid id)
        {
            var result = context.Albums
                .Include(x => x.Artist.Label)
                .Single(x => x.Id == id);

            if (result == null)
                return null;

            return new AlbumDetailsModel
            {
                Artist = result.Artist.Name,
                Label = result.Artist.Label.Name,
                Id = result.Id,
                Name = result.Name,
                Stock = result.Stock,
                Type = result.Type == AlbumType.CD ? "CD" : "Vinyl"
            };
        }

        public DeleteAlbumResultModel Delete(Guid albumId)
        {
            var album = context.Albums
                .Include(x => x.Artist)
                .Single(x => x.Id == albumId);

            var artist = album.Artist.Name;
            var albumName = album.Name;

            context.Albums.Remove(album);
            context.SaveChanges();

            return new DeleteAlbumResultModel()
            {
                Message = $"Successfully deleted {artist}'s Album \"{albumName}\""
            };
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

        public AlbumListModel GetAllPagedAndSorted(int page, int take, string sort, SortDirection direction)
        {
            var albums = context.Albums
                .Include(x => x.Artist.Label)
                .OrderBy(x => x.Artist.Name);

            var sorted = string.IsNullOrWhiteSpace(sort) ? albums : GetSorted(sort, direction, albums);

            var pagedList = sorted.Select(x => new AlbumListItemModel()
            {
                Id = x.Id,
                Artist = x.Artist.Name,
                Name = x.Name,
                Stock = x.Stock,
                Type = x.Type == AlbumType.CD ? "CD" : "Vinyl"
            }).ToPagedList(page, take);

            return new AlbumListModel
            {
                Albums = (PagedList<AlbumListItemModel>)pagedList,
                Page = page,
                PageSize = take,
                Sort = sort,
                SortDirection = direction
            };
        }

        public CreateAlbumRequestModel GetDefaultCreateModel() => new CreateAlbumRequestModel()
        {
            AlbumType = AlbumType.CD,
            ArtistId = Guid.Empty,
            Artists = context.Artists.Select(x => new ArtistListItemModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToArray(),
            Name = string.Empty,
            Stock = 0
        };
    }
}
