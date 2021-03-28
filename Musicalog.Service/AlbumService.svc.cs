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
        //private static readonly IQueryable<Artist> artists = new List<Artist>()
        //{
        //    new Artist()
        //    {
        //        Name = "Ed Sheeran",
        //        Id = Guid.NewGuid(),
        //        Label = new Label()
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "Dan Scott Records"
        //        }
        //    }
        //}
        //.AsQueryable();

        //private static readonly IQueryable<Album> albums = new List<Album>()
        //{
        //    new Album()
        //    {
        //        Id = Guid.Parse("0fff7552-0db4-4f5d-baf3-e5a5833b211c"),
        //        Artist = artists.First(),
        //        Name = "Shape of You",
        //        Stock = 100,
        //        Type = AlbumType.CD
        //    }
        //}.AsQueryable();

        private readonly IAlbumMapper mapper;
        private readonly AlbumsContext context;

        public AlbumService(
            IAlbumMapper mapper,
            AlbumsContext context
        )
        {
            this.mapper = mapper;
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
                Message = $"Successfully created album {model.Name} for {context.Artists.Single(x => x.Id == model.ArtistId).Name}"
            };
        }

        public AlbumDetailsModel GetById(Guid id)
        {
            var result = context.Albums
                .Include(x => x.Artist.Label)
                .Single(x => x.Id == id);

            if (result == null)
                return null;

            return mapper.ToDetailModel(result);
        }

        public AlbumListModel GetAllPagedAndSorted(int page, int take, string sort, SortDirection direction)
        {
            var albums = context.Albums
                .Include(x => x.Artist.Label)
                .OrderBy(x => x.Artist.Name);

            var sorted = string.IsNullOrWhiteSpace(sort) ? albums : albums.Sort(sort, direction);

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
