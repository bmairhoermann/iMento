using imento.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static imento.Views.EntryView;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace imento.Views {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PhotoView : Page {

        ModelController mc = new ModelController();
        Photo photo = new Photo();
        private int PhotoId;
        private bool currentPhotoIsFavorite = false;

        public PhotoView() {
            this.InitializeComponent();
        }

        /// <summary>
        /// Receives information from the item clicked in the previous view (entry view) and sets the favorite button according to the photo
        /// </summary>
        /// <param name="e"></param>
        protected override async void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);

            PhotoParams result = (PhotoParams)e.Parameter;
            photo = mc.getPhoto(result.PhotoId);
            PhotoId = result.PhotoId;
            ImageSource imageSource = await photo.ToBitmapImage();
            DisplayPhoto.Source = imageSource;

            if (photo.isFavourite) {
                currentPhotoIsFavorite = true;
                makeFavorite.Content = "Von den Favoriten entfernen";
            }
        }

        /// <summary>
        /// Makes a photo a favorite or removes the favorite state if it already has it 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void makePhotoFavorite_Click(object sender, RoutedEventArgs e) {
            if (currentPhotoIsFavorite) {
                makeFavorite.Content = "Zu Favoriten hinzufügen";
                mc.updatePhoto(PhotoId, false);
                currentPhotoIsFavorite = false;
            } else {
                makeFavorite.Content = "Von den Favoriten entfernen";
                mc.updatePhoto(PhotoId, true);
                currentPhotoIsFavorite = true;
            }
        }

        /// <summary>
        /// Deletes the Photo after confirming the message dialog 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void deletePhoto_Click(object sender, RoutedEventArgs e) {
            var dialog = new Windows.UI.Popups.MessageDialog("Wollen Sie wirklich dieses Foto löschen?");

            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Ja") { Id = 0 });
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Abbrechen") { Id = 1 });
            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 1;

            var result = await dialog.ShowAsync();
            var btn = sender as Button;

            if ((int)result.Id == 0) {
                mc.deletePhoto(PhotoId);
                this.Frame.Navigate(typeof(AllAlbumsView));
            }
        }
    }
}
