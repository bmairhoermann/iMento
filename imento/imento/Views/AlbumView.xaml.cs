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
using System.Collections.ObjectModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace imento.Views {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AlbumView : Page {

        private ObservableCollection<EntryViewModel> Entrys;
        private Album album;

        ModelController mc = new ModelController();

        Photo photo = new Photo();

        public String Title = "Album";

        public AlbumView() {
            this.InitializeComponent();
        }

        /// <summary>
        /// Receives information from the item clicked in the previous view (all albums view)  nd uses it to set strings, text boxes and filling the view with entries
        /// </summary>
        /// <param name="e">
        /// Receives data about the clicked item 
        /// </param>
        protected async override void OnNavigatedTo(NavigationEventArgs e) {
            AlbumParams result = (AlbumParams)e.Parameter;
            album = mc.getAlbum(result.AlbumId);

            // Check if Album is not null
            if(album.AlbumId != null) {
                AlbumTitleHeadline.Text = result.AlbumTitle;

                try {
                    AlbumDescriptionParagraph.Text = result.AlbumDescription;
                    AlbumTypeIcon.Text = result.AlbumType;
                } catch { }

                base.OnNavigatedTo(e);

                var dbEntries = mc.getEntriesOverview(album.AlbumId);
                Entrys = new ObservableCollection<EntryViewModel>();
                foreach (Entry item in dbEntries) {
                    EntryViewModel entryViewModel = new EntryViewModel();
                    entryViewModel.EntryId = item.EntryId;
                    entryViewModel.Title = item.Title;
                    entryViewModel.Description = item.Description;
                    if (item.Photos != null) {
                        entryViewModel.Photo = await item.Photos[0].ToBitmapImage();
                    }
                    Entrys.Add(entryViewModel);
                }
            } else {
                AlbumTitleHeadline.Text = "Gelöschtes Album";
                AlbumDescriptionParagraph.Text = "Gelöschtes Album";
                editAlbum.IsEnabled = false;
                deleteAlbum.IsEnabled = false;
                newEntryButton.IsEnabled = false;
            }
            
        }

        /// <summary>
        /// Click on an entry opens it in the entry view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">
        /// Gives information about the clicked item 
        /// </param>
        private void GridView_ItemClick(object sender, ItemClickEventArgs e) {
            var entry = (EntryViewModel)e.ClickedItem;
            this.Frame.Navigate(typeof(Views.EntryView), new EntryParams() { EntryId = entry.EntryId, EntryTitle = entry.Title, EntryDescription = entry.Description });
        }

        /// <summary>
        /// Params for the clicked entry used to pass to the entry view 
        /// </summary>
        public class EntryParams {
            public int EntryId { get; set; }
            public string EntryTitle { get; set; }
            public string EntryDescription { get; set; }

            public DateTime Date { get; set; }
        }

        /// <summary>
        /// Open a new dialog to create a new entry an save them to the database according to the album id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void NewEntry_Click(object sender, RoutedEventArgs e) {
            Entry entry = new Entry();
            AddEntry dialog = new AddEntry(entry);
            var dialogResult = await dialog.ShowAsync();
            try {
                if (dialog.hasChanged == true) {
                    mc.saveNewEntry(entry, album.AlbumId);
                    var dbEntry = mc.getEntriesOverview(album.AlbumId).Last();

                    EntryViewModel entryViewModel = new EntryViewModel();
                    entryViewModel.EntryId = dbEntry.EntryId;
                    entryViewModel.Title = dbEntry.Title;
                    entryViewModel.Description = dbEntry.Description;
                    Entrys.Add(entryViewModel);
                }
            } catch {
                System.Diagnostics.Debug.WriteLine("ALBUMVIEW: edit_Album_Click(): Not able to update Album!");
            }
        }

        /// <summary>
        /// After confirming the message dialog it deletes an album by id and changes view to AllAlbumsView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void deleteAlbum_Click(object sender, RoutedEventArgs e) {
            var dialog = new Windows.UI.Popups.MessageDialog("Wollen Sie wirklich dieses Album löschen?");

            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Ja") { Id = 0 });
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Abbrechen") { Id = 1 });
            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 1;

            var result = await dialog.ShowAsync();
            var btn = sender as Button;

            if ((int)result.Id == 0) {
                mc.deleteAlbum(album.AlbumId);
                this.Frame.Navigate(typeof(AllAlbumsView));
            } 
        }

        /// <summary>
        /// Open the content dialog to edit the album
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void editAlbum_Click(object sender, RoutedEventArgs e) {
            ContentDialogMap dialog = new ContentDialogMap(album);
            var dialogResult = await dialog.ShowAsync();

            try {
               if (dialog.hasChanged == true) {
                    album = dialog.album;
                    AlbumTitleHeadline.Text = album.Title;
                    AlbumDescriptionParagraph.Text = album.Description;
                    AlbumTypeIcon.Text = album.Type;
                    mc.updateAlbumInfo(album);
                }
            } catch {
                System.Diagnostics.Debug.WriteLine("ALBUMVIEW: edit_Album_Click(): Not able to update Album!");
            }
        }
    }
}
