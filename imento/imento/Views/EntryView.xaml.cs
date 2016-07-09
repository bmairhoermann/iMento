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
        ModelController mc = new ModelController();
        private ObservableCollection<PhotoViewModel> Photos;
        private Entry currentEntry = new Entry();

        public string albumId;
        public int EntryId;
        public string EntryTitle;
        public string EntryDescription;

        public EntryView() {
            this.InitializeComponent();
        }

        /// <summary>
        /// Receives information from the item clicked in the previous view (album view) and uses it to set strings and text boxes
        /// </summary>
        /// <param name="e">
        ///  Gives information about the clicked item 
        /// </param>
        protected override async void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);

            // Hide the praesentation mode by default
            PresentationView.Visibility = Visibility.Collapsed;

            EntryParams result = (EntryParams)e.Parameter;
            EntryId = result.EntryId;
            EntryTitle = result.EntryTitle;
            EntryDescription = result.EntryDescription;

            EntryTitleHeadline.Text = result.EntryTitle;
            EntryDescriptionParagraph.Text = result.EntryDescription;

            fillObservableListWithPhotos();
        }

        /// <summary>
        /// Load photo view an pass photo data to load matching photo 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView_ItemClick(object sender, ItemClickEventArgs e) {
            var photo = (PhotoViewModel)e.ClickedItem; 
            this.Frame.Navigate(typeof(Views.PhotoView), new PhotoParams() { PhotoId = photo.PhotoId });
        }

        /// <summary>
        /// Params for the clicked photo used to pass to the photo view 
        /// </summary>
        public class PhotoParams {
            public int PhotoId { get; set; }
        }

        /// <summary>
        /// Opens the content dialog to add a new photo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void NewPhoto_Click(object sender, RoutedEventArgs e) {
            AddPhoto dialog = new AddPhoto(EntryId);
            var dialogResult = await dialog.ShowAsync();
            if (dialog.photoWasAdded) {
                currentEntry = mc.getEntryDetails(EntryId);
                PhotoViewModel newPhotoViewModel = new PhotoViewModel();
                newPhotoViewModel.Photo = await currentEntry.Photos.Last().ToBitmapImage();
                newPhotoViewModel.PhotoId = currentEntry.Photos.Last().PhotoId;
                Photos.Add(newPhotoViewModel);
            }
        }

        /// <summary>
        /// Fills the photolist with the photos from the entry
        /// </summary>
        private async void fillObservableListWithPhotos() {
            currentEntry = mc.getEntryDetails(EntryId);
            Photos = new ObservableCollection<PhotoViewModel>();

            //Check if Entry still exists
            if(currentEntry.EntryId != 0) {
                foreach (Photo photo in currentEntry.Photos) {
                    var photoViewModel = new PhotoViewModel();
                    photoViewModel.Photo = await photo.ToBitmapImage();
                    photoViewModel.PhotoId = photo.PhotoId;
                    Photos.Add(photoViewModel);
                }
            } else {
                EntryTitleHeadline.Text = "Eintrag wurde gelöscht.";
                EntryDescriptionParagraph.Text = "Eintrag wurde gelöscht";
                editEntry.IsEnabled = false;
                addPhotoButton.IsEnabled = false;
                deleteEntry.IsEnabled = false;

            }
            
        }

        /// <summary>
        /// After confirming the message dialog it deletes an entry by id and changes view to AllAlbumsView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void deleteEntry_Click(object sender, RoutedEventArgs e) {
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

        /// <summary>
        /// Open the content dialog to edit the entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Displays the presentation mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenPresentation_Click(object sender, RoutedEventArgs e) {
            PresentationView.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Hides the presentation mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClosePresentation_Click(object sender, RoutedEventArgs e) {
            PresentationView.Visibility = Visibility.Collapsed;
        }
    }

}



