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
        private readonly IQueryable<Album> albums = new List<Album>()
        {
            new Album()
            {
                Id = Guid.Parse("0fff7552-0db4-4f5d-baf3-e5a5833b211c"),
                Artist = new Artist()
                {
                    Name = "Ed Sheeran",
                    Id = Guid.NewGuid(),
                    Label = new Label()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Dan Scott Records"
                    }
                },
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

        public Guid AddAlbum(CreateAlbumModel model)
        {
            return Guid.NewGuid();
        }

        public AlbumDetailsModel GetAlbum(Guid id)
        {
            var result = albums.FirstOrDefault(x => x.Id == id);
            if (result == null)
                return null;

            return mapper.ToDetailModel(result);
        }

        public AlbumListModel GetAlbums(int page, int take, string sort, SortDirection direction)
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
    }
}
