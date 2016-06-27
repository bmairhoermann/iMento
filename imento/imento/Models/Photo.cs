using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace imento.Models {
    public class Photo {
        public int PhotoId { get; set; }

        // ForeignKey for Entrys
        public int EntryId { get; set; }
        [ForeignKey("EntryId")]
        public Entry Entry { get; set; }

        public bool isFavourite { get; set; }
        public byte[] ImageByteArray { get; set; }


        public async Task<BitmapImage> ToBitmapImage() {
            using (var ms = new MemoryStream(ImageByteArray)) {
                var bitmapImage = new BitmapImage();
                await bitmapImage.SetSourceAsync(ms.AsRandomAccessStream());
                return bitmapImage;
            }
        }
    }




}
