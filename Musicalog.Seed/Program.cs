using Musicalog.Data;
using Musicalog.Data.Models;
using System.Collections.Generic;

namespace Musicalog.Seed
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new AlbumsContext();
            var nuclearBlast = new Label() { Name = "Nuclear Blast Records" };
            var riseRecords = new Label() { Name = "Rise Records" };
            var summarian = new Label() { Name = "Summarian Records" };

            var sws = new Artist() { Name = "Sleeping With Sirens", Label = riseRecords };
            var ptv = new Artist() { Name = "Pierce the Veil", Label = riseRecords };
            var buryTomorrow = new Artist() { Name = "Nuclear Blast", Label = nuclearBlast };
            var askingAlexandria = new Artist() { Name = "Asking Alexandria", Label = summarian };

            context.Labels.AddRange(new List<Label>() {
                riseRecords,
                nuclearBlast,
                summarian
            });

            context.Artists.AddRange(new List<Artist>()
            {
                ptv,
                sws,
                buryTomorrow,
                askingAlexandria
            });

            context.Albums.AddRange(new List<Album>()
            {
                new Album()
                {
                    Artist = ptv,
                    Name = "Collide with the Sky",
                    Stock = 100,
                    Type = AlbumType.CD
                },
                new Album()
                {
                    Artist = sws,
                    Name = "With Ears to See and Eyes to Hear",
                    Stock = 100, 
                    Type = AlbumType.CD
                }
            });

            context.SaveChanges();
        }
    }
}
