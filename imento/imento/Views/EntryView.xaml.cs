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

        public string albumId;
        public int EntryId;
        public string EntryTitle;
        public string EntryDescription;

        ModelController mc = new ModelController();

        public EntryView() {
            this.InitializeComponent();
            // mc.dostuff();
        }

        // If AlbumId is passed, it will be set to the String albumId
        protected override async void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);

            EntryParams result = (EntryParams)e.Parameter;
            EntryId = result.EntryId;
            EntryTitle = result.EntryTitle;
            EntryDescription = result.EntryDescription;

            EntryTitleHeadline.Text = result.EntryTitle;
            EntryDescriptionParagraph.Text = result.EntryDescription;

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
            AddPhoto dialog = new AddPhoto(EntryId);
            var dialogResult = await dialog.ShowAsync();
            if (dialog.photoWasAdded)
            {
                currentEntry = mc.getEntryDetails(EntryId);
                PhotoViewModel newPhotoViewModel = new PhotoViewModel();
                newPhotoViewModel.Photo = await currentEntry.Photos.Last().ToBitmapImage();
                newPhotoViewModel.PhotoId = currentEntry.Photos.Last().PhotoId;
                Photos.Add(newPhotoViewModel);
            }
        }

        private async void fillObservableListWithPhotos()
        {
            currentEntry = mc.getEntryDetails(EntryId);
            Photos = new ObservableCollection<PhotoViewModel>();

            foreach (Photo photo in currentEntry.Photos)
            {
                var photoViewModel = new PhotoViewModel();
                photoViewModel.Photo = await photo.ToBitmapImage();
                photoViewModel.PhotoId = photo.PhotoId;
                Photos.Add(photoViewModel);
            }
        }

        private async void deleteEntry_Click(object sender, RoutedEventArgs e) {
            // MessageDialog
            var dialog = new Windows.UI.Popups.MessageDialog("Wollen Sie wirklich diesen Eintrag löschen?");

            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Ja") { Id = 0 });
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Abbrechen") { Id = 1 });

            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 1;

            var result = await dialog.ShowAsync();

            var btn = sender as Button;

            if ((int)result.Id == 0) {
                mc.deleteEntry(EntryId);
                this.Frame.Navigate(typeof(AllAlbumsView));
            }
        }

        private async void editEntry_Click(object sender, RoutedEventArgs e) {
            AddEntry dialog = new AddEntry(currentEntry);
            var dialogResult = await dialog.ShowAsync();
            
            try {
                if (dialog.hasChanged == true) {
                    currentEntry = dialog.entry;
                    EntryTitleHeadline.Text = currentEntry.Title;
                    EntryDescriptionParagraph.Text = currentEntry.Description;

                    mc.updateEntry(currentEntry);
                }
            } catch {
                System.Diagnostics.Debug.WriteLine("ALBUMVIEW: edit_Album_Click(): Not able to update Album!");
            }
        }
    }
}



