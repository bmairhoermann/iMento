using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imento.Models {
    public class Album {
        public int AlbumId { get; set; }
        public string AlbumTitle { get; set; }
        public string AlbumDescription { get; set; }
        public string HolidayType { get; set; }
        public string Location { get; set; }
        public string PicSource { get; set; }
        // public int[] PictureIds;
    }

    public class AlbumManager {
        public static List<Album> GetAlbums() {
            var albums = new List<Album>();
            int[] pic = { 1, 2, 3 };

            albums.Add(new Album {
                AlbumId = 1,
                AlbumTitle = "Barcelona",
                AlbumDescription = "Beschreibungstext für ein Album",
                HolidayType = "Strandurlaub",
                Location = "Barcelona",
                PicSource = "../Pictures/pic01.jpg"
            });

            albums.Add(new Album {
                AlbumId = 2,
                AlbumTitle = "Strand",
                AlbumDescription = "Beschreibungstext für ein Album",
                HolidayType = "Strandurlaub",
                Location = "Barcelona",
                PicSource = "../Pictures/pic02.jpg"
            });

            albums.Add(new Album {
                AlbumId = 3,
                AlbumTitle = "Wandern",
                AlbumDescription = "Beschreibungstext für ein Album",
                HolidayType = "Strandurlaub",
                Location = "Barcelona",
                PicSource = "../Pictures/pic03.jpg"
            });
            albums.Add(new Album {
                AlbumId = 4,
                AlbumTitle = "Zeuch",
                AlbumDescription = "Beschreibungstext für ein Album",
                HolidayType = "Strandurlaub",
                Location = "Barcelona",
                PicSource = "../Pictures/pic04.jpg"
            });

            albums.Add(new Album {
                AlbumId = 5,
                AlbumTitle = "asdf",
                AlbumDescription = "Beschreibungstext für ein Album",
                HolidayType = "Strandurlaub",
                Location = "Barcelona",
                PicSource = "../Pictures/pic05.jpg"
            });
            albums.Add(new Album {
                AlbumId = 6,
                AlbumTitle = "Test",
                AlbumDescription = "Beschreibungstext für ein Album",
                HolidayType = "Strandurlaub",
                Location = "Barcelona",
                PicSource = "../Pictures/pic06.jpg"
            });

            albums.Add(new Album {
                AlbumId = 7,
                AlbumTitle = "Test",
                AlbumDescription = "Beschreibungstext für ein Album",
                HolidayType = "Strandurlaub",
                Location = "Barcelona",
                PicSource = "../Pictures/pic07.jpg"
            });
            albums.Add(new Album {
                AlbumId = 8,
                AlbumTitle = "Test",
                AlbumDescription = "Beschreibungstext für ein Album",
                HolidayType = "Strandurlaub",
                Location = "Barcelona",
                PicSource = "../Pictures/pic08.jpg"
            });



            return albums; 
        }
    }
}
