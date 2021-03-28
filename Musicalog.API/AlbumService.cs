using Musicalog.API.Models;
using Musicalog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using Musicalog.API.Extensions;

namespace Musicalog.API
{
    public class AlbumService : IAlbumService
    {
        private static readonly IQueryable<Artist> artists = new List<Artist>()
        {
            new Artist()
            {
                Name = "Ed Sheeran",
                Id = Guid.NewGuid(),
                Label = new Label()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dan Scott Records"
                }
            }
        }
        .AsQueryable();

        private static readonly IQueryable<Album> albums = new List<Album>()
        {
            new Album()
            {
                Id = Guid.Parse("0fff7552-0db4-4f5d-baf3-e5a5833b211c"),
                Artist = artists.First(),
                Name = "Shape of You",
                Stock = 100,
                Type = AlbumType.CD
            }
        }.AsQueryable();

        private readonly IAlbumMapper mapper;

        public AlbumService()
        {
            mapper = new AlbumMapper();
        }

        public CreateAlbumResultModel Create(CreateAlbumRequestModel model) =>
            new CreateAlbumResultModel()
            {
                Success = true,
                Message = $"Successfully created album {model.Name} for {artists.Single(x => x.Id == model.ArtistId).Name}"
            };

        public AlbumDetailsModel GetById(Guid id)
        {
            var result = albums.Single(x => x.Id == id);
            if (result == null)
                return null;

            return mapper.ToDetailModel(result);
        }

        public AlbumListModel GetAllPagedAndSorted(int page, int take, string sort, SortDirection direction)
        {
            var sorted = string.IsNullOrWhiteSpace(sort) ? albums : albums.Sort(sort, direction);
            var pagedList = sorted.Select(x => mapper.ToListModel(x))
                    .ToPagedList(page, take);

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
            Artists = artists.Select(x => new ArtistListItemModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToArray(),
            Name = string.Empty,
            Stock = 0
        };
    }
}
