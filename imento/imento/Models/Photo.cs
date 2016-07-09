using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace imento.Models {
    /// <summary>
    /// Class that sets the Modelstructure of a Photo
    /// </summary>
    public class Photo {

        /// <summary>
        /// Database identifier
        /// </summary>
        public int PhotoId { get; set; }

        /// <summary>
        /// ForeignKey for Entrys
        /// </summary>
        public int EntryId { get; set; }
        [ForeignKey("EntryId")]
        public Entry Entry { get; set; }

        /// <summary>
        /// Boolean whether this Photo is a favourite or not
        /// </summary>
        public bool isFavourite { get; set; }

        /// <summary>
        /// Databaseformat for the Picture
        /// </summary>
        public byte[] ImageByteArray { get; set; }

        /// <summary>
        /// Asynchmethod for converting a byte array to a bitMapImage object
        /// </summary>
        /// <returns>BitmapImage</returns>
        public async Task<BitmapImage> ToBitmapImage() {
            using (var ms = new MemoryStream(ImageByteArray)) {
                var bitmapImage = new BitmapImage();
                await bitmapImage.SetSourceAsync(ms.AsRandomAccessStream());
                return bitmapImage;
            }
        }
    }




}
