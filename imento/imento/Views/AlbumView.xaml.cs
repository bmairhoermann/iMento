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

        private ObservableCollection<Entry> Entrys;
        public String AlbumId;
        public String AlbumTitle;
        public String AlbumDescription;
        public String AlbumType;
        public DateTime AlbumDate_Start;
        public DateTime AlbumDate_Ende;




        ModelController mc = new ModelController();

        public String Title = "Album";

        public AlbumView() {
            this.InitializeComponent();
        }

        // If AlbumId is passed, it will be set to the String albumId
        protected override void OnNavigatedTo(NavigationEventArgs e) {
            AlbumParams result = (AlbumParams)e.Parameter;

            AlbumId = result.AlbumId;
            AlbumTitle = result.AlbumTitle;
            AlbumDescription = result.AlbumDescription;
            AlbumType = result.AlbumType;
            AlbumDate_Start = result.AlbumDate_Start;
            AlbumDate_Ende = result.AlbumDate_Ende;

            AlbumTitleHeadline.Text = result.AlbumTitle;            

            base.OnNavigatedTo(e);
            
            Entrys = new ObservableCollection<Entry>(mc.getEntriesOverview(AlbumId));
        }

        // Click on an entry opens it in a new view
        private void GridView_ItemClick(object sender, ItemClickEventArgs e) {
            var entry = (Entry)e.ClickedItem;
            this.Frame.Navigate(typeof(Views.EntryView), new EntryParams() { EntryId = entry.EntryId, EntryTitle = entry.Title, EntryDescription = entry.Description });
        }
        public class EntryParams {

            public int EntryId { get; set; }
            public string EntryTitle { get; set; }
            public string EntryDescription { get; set; }

            public DateTime Date { get; set; }
        }


        // Open a new dialog to create a new entry an save them to the databse according to the album id
        private async void NewEntry_Click(object sender, RoutedEventArgs e) {
            AddEntry dialog = new AddEntry();
            var dialogResult = await dialog.ShowAsync();
            try {
                if (dialog.Title != "" && dialog.hasChanged == true) {
                    var Entry = new Entry();

                    Entry.Title = dialog.Title;
                    Entry.Description = dialog.Desc;

                    mc.saveNewEntry(Entry, AlbumId);

                    Entrys.Add(Entry);
                }
            } catch {
                System.Diagnostics.Debug.WriteLine("ALBUMVIEW: edit_Album_Click(): Not able to update Album!");
            }

        }

        // Deletes an album by id and changes view to AllAlbumsView
        private async void deleteAlbum_Click(object sender, RoutedEventArgs e) {
            // MessageDialog
            var dialog = new Windows.UI.Popups.MessageDialog("Wollen Sie wirklich dieses Album löschen?");

            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Ja") { Id = 0 });
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Abbrechen") { Id = 1 });

            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 1;

            var result = await dialog.ShowAsync();

            var btn = sender as Button;

            if ((int)result.Id == 0) {
                mc.deleteAlbum(AlbumId);
                this.Frame.Navigate(typeof(AllAlbumsView));
            } 
 
        }
        // Edit the album
        private async void editAlbum_Click(object sender, RoutedEventArgs e) {
            ContentDialogMap dialog = new ContentDialogMap(AlbumId, AlbumTitle, AlbumDescription, AlbumType, AlbumDate_Start, AlbumDate_Ende);
            var dialogResult = await dialog.ShowAsync();

            // Create Album
            var Album = new Album();

            // IMPORTANT: SET ALBUMID WHEN CREATING NEW ALBUM
            Album.AlbumId = dialog.AlbumId;

            try
            {
               if (dialog.AlbumTitle != "" && dialog.hasChanged == true)
                {
                    Album.Title = dialog.AlbumTitle;
                    Album.Description = dialog.AlbumDescription;
                    Album.Type = dialog.AlbumType;
                    Album.Date_Start = new DateTime(2015, 1, 7); // ??? 
                    Album.Date_Ende = new DateTime(2015, 1, 10); // ??? 

                    AlbumTitleHeadline.Text = dialog.AlbumTitle;

                    // Album.Entries = EntryList;

                    mc.updateAlbumInfo(Album);
                }
            }catch
            {
                System.Diagnostics.Debug.WriteLine("ALBUMVIEW: edit_Album_Click(): Not able to update Album!");
            }
            
        }
    }
}
