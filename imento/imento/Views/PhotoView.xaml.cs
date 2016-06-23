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

        public PhotoView() {
            this.InitializeComponent();
        }
        


        protected override async void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);

            PhotoParams result = (PhotoParams)e.Parameter;

            photo = mc.getPhoto(result.PhotoId);

            PhotoId = result.PhotoId;

            ImageSource imageSource = await photo.ToBitmapImage();
            DisplayPhoto.Source = imageSource;

        }

        private async void deletePhoto_Click(object sender, RoutedEventArgs e) {
            // MessageDialog
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
