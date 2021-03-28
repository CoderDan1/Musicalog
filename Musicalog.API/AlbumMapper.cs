using Musicalog.API.Models;
using Musicalog.Data.Models;
using System;

namespace Musicalog.API
{
    public class AlbumMapper : IAlbumMapper
    {
        public AlbumDetailsModel ToDetailModel(Album album) => new AlbumDetailsModel()
        {
            Id = album.Id,
            Artist = album.Artist.Name,
            Label = album.Artist.Label.Name,
            Name = album.Name,
            Stock = album.Stock,
            Type = AlbumTypeToString(album.Type)
        };

        public AlbumListItemModel ToListModel(Album album) => new AlbumListItemModel()
        {
            Id = album.Id,
            Artist = album.Artist.Name,
            Name = album.Name,
            Stock = album.Stock,
            Type = AlbumTypeToString(album.Type)
        };

        private string AlbumTypeToString(AlbumType type)
        {
            switch (type)
            {
                case AlbumType.CD:
                    return "CD";
                case AlbumType.Vinyl:
                    return "Vinyl";
                default:
                    throw new Exception($"Unknown Album Type {type}");
            }
        }
    }
}
