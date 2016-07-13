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

        public bool photoWasAdded { get; set; }
        public int addCount = 0;

        private List<byte[]> byteArrayList = new List<byte[]>();

        ModelController mc = new ModelController();

        private int entryId;

        public AddPhoto(int entryId) {
            this.entryId = entryId;
            this.InitializeComponent();
        }

        /// <summary>
        /// Saves the given Photos to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args) {

            if (byteArrayList.Count > 0) {
                foreach(byte[] item in byteArrayList) {
                    if (item != null && item.Length > 0) {
                        // Save new Photo to Database
                        Entry oldEntry = mc.getEntryDetails(entryId);

                        Photo newPhoto = new Photo();
                        newPhoto.EntryId = oldEntry.EntryId;
                        newPhoto.ImageByteArray = item;

                        oldEntry.Photos.Add(newPhoto);

                        mc.updateEntry(oldEntry);

                        addCount += 1;
                        photoWasAdded = true;
                    }
                }
            } else {
                photoWasAdded = false;
            }
        }

        /// <summary>
        /// Abborts adding photos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args) {
            photoWasAdded = false;
        }

        /// <summary>
        /// Prepares a Grid for filedropping
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_DragOver(object sender, DragEventArgs e) {
            // Prepare for Drop
            e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Copy;
        }

        /// <summary>
        /// Handles the userinput and decides what to do with it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Grid_Drop(object sender, DragEventArgs e) {
            // Routine for getting the stuff dropped into the grid
            if (e.DataView.Contains(StandardDataFormats.StorageItems)) {
                var items = await e.DataView.GetStorageItemsAsync();
                byteArrayList = new List<byte[]>();
                if (items.Any()) {
                    foreach(StorageFile item in items) {
                        var storageFile = item as StorageFile;

                        // Check if given data is valide
                        if (storageFile.ContentType == "image/jpeg" || storageFile.ContentType == "image/bmp" || storageFile.ContentType == "image/gif" || storageFile.ContentType == "image/png") {
                            // Write Inputstream to buffer and write buffer to byte-Array
                            var buffer = await FileIO.ReadBufferAsync(storageFile);
                            var byteArray = buffer.ToArray();
                            byteArrayList.Add(byteArray);
                        }
                    }
                    if (byteArrayList.Count > 0) {
                        // BELOW: FOR FURTHER USAGE:
                        // parse byte[] in Bitmap
                        var mypicture = await ToBitmapImage(byteArrayList[0]);

                        // Set Bitmap as Picture Source for Image in View
                        ImageSource imageSource = mypicture; // put the bitmapImage into a ImageSource
                        DroppedImage.Source = imageSource; // Set source of windows.UI.xaml.Control.Image to this imageSource

                        countItemsText.Text = "";

                        if (byteArrayList.Count > 1) {
                            countItemsText.Text = "+" + (byteArrayList.Count - 1);
                        }
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
