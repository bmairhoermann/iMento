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
using imento.Models;
using System.Diagnostics;
using static imento.Views.AlbumView;
using System.Collections.ObjectModel;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace imento.Views {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EntryView : Page {

        private ObservableCollection<PhotoViewModel> Photos;
        private Entry currentEntry = new Entry();

        //private List<ImageSource> PicSource;

        public String albumId;
        public int entryId;
        ModelController mc = new ModelController();

        public EntryView() {
            this.InitializeComponent();
            // mc.dostuff();
        }

        // If AlbumId is passed, it will be set to the String albumId
        protected override async void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);

            EntryParams result = (EntryParams)e.Parameter;
            entryId = result.EntryId;

            fillObservableListWithPhotos();
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e) {
            var photo = (PhotoViewModel)e.ClickedItem; 
            this.Frame.Navigate(typeof(Views.PhotoView), new PhotoParams() { PhotoId = photo.PhotoId });
        }
        public class PhotoParams {
            public int PhotoId { get; set; }
        }

        private async void NewPhoto_Click(object sender, RoutedEventArgs e) {
            AddPhoto dialog = new AddPhoto(entryId);
            var dialogResult = await dialog.ShowAsync();
            if (dialog.photoWasAdded)
            {
                currentEntry = mc.getEntryDetails(entryId);
                PhotoViewModel newPhotoViewModel = new PhotoViewModel();
                newPhotoViewModel.Photo = await currentEntry.Photos.Last().ToBitmapImage();
                newPhotoViewModel.PhotoId = currentEntry.Photos.Last().PhotoId;
                Photos.Add(newPhotoViewModel);
            }
        }

        private async void fillObservableListWithPhotos()
        {
            currentEntry = mc.getEntryDetails(entryId);
            Photos = new ObservableCollection<PhotoViewModel>();

            foreach (Photo photo in currentEntry.Photos)
            {
                var photoViewModel = new PhotoViewModel();
                photoViewModel.Photo = await photo.ToBitmapImage();
                photoViewModel.PhotoId = photo.PhotoId;
                Photos.Add(photoViewModel);
            }
        }

    }
}



