using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imento.Models {
    /// <summary>
    /// Deprecated class for testing
    /// </summary>
    public class Picture {
        public int PictureId { get; set; }
        public string PicturePath { get; set; }
        public bool IsFavorite { get; set; }
    }

    public class PictureManager {
        public static List<Picture> GetPictures() {
            var pictures = new List<Picture>();
            pictures.Add(new Picture { PictureId = 1, PicturePath = "Pictures/pic01.jpg ", IsFavorite = false });
            pictures.Add(new Picture { PictureId = 2, PicturePath = "Pictures/pic02.jpg ", IsFavorite = true });
            pictures.Add(new Picture { PictureId = 3, PicturePath = "Pictures/pic03.jpg ", IsFavorite = false });
            return pictures;
        }
    }
}
