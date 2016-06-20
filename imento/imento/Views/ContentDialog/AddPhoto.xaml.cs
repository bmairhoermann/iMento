using imento.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace imento.Views {
    public sealed partial class AddPhoto : ContentDialog {

        private byte[] byteArray;

        ModelController mc = new ModelController();

        private int entryId;

        public AddPhoto(int entryId) {
            this.entryId = entryId;
            this.InitializeComponent();
        }
        // ok
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args) {

            if (byteArray != null && byteArray.Length > 0)
            {
                Entry oldEntry = mc.getEntryDetails(entryId);

                Photo newPhoto = new Photo();
                newPhoto.EntryId = oldEntry.EntryId;
                newPhoto.ImageByteArray = byteArray;

                oldEntry.Photos.Add(newPhoto);

                mc.updateEntry(oldEntry);
            }
            
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args) {
        }

        private void Grid_DragOver(object sender, DragEventArgs e) {
            // Prepare for Drop
            e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Copy;
        }

        private async void Grid_Drop(object sender, DragEventArgs e) {
            // Routine for getting the stuff dropped into the grid
            if (e.DataView.Contains(StandardDataFormats.StorageItems)) {
                var items = await e.DataView.GetStorageItemsAsync();

                if (items.Any()) {
                    var storageFile = items[0] as StorageFile;

                    // Check if given data is valide
                    if (storageFile.ContentType == "image/jpeg" || storageFile.ContentType == "image/bmp" || storageFile.ContentType == "image/gif" || storageFile.ContentType == "image/png") {
                        // Write Inputstream to buffer and write buffer to byte-Array
                        var buffer = await FileIO.ReadBufferAsync(storageFile);
                        byteArray = buffer.ToArray(); // 

                        // BELOW: FOR FURTHER USAGE:
                        // parse byte[] in Bitmap
                        var mypicture = await ToBitmapImage(byteArray);

                        // Set Bitmap as Picture Source for Image in View
                        ImageSource imageSource = mypicture; // put the bitmapImage into a ImageSource
                        DroppedImage.Source = imageSource; // Set source of windows.UI.xaml.Control.Image to this imageSource

                    }
                }
            }
        }

        // Method for Parsing a byte-Array to a BitmapImage
        public async Task<BitmapImage> ToBitmapImage(byte[] array) {
            using (var ms = new MemoryStream(array)) {
                var bitmapImage = new BitmapImage();
                await bitmapImage.SetSourceAsync(ms.AsRandomAccessStream());
                return bitmapImage;
            }
        }
    }
}
