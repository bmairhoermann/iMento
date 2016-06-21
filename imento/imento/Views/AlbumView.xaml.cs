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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace imento.Views {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AlbumView : Page {

        private List<Entry> Entrys;
        public String albumId;
        ModelController mc = new ModelController();

        public String Title = "Album";

        public AlbumView() {
            this.InitializeComponent();
        }

        // If AlbumId is passed, it will be set to the String albumId
        protected override void OnNavigatedTo(NavigationEventArgs e) {
            AlbumParams result = (AlbumParams)e.Parameter;

            albumId = result.AlbumId;
            AlbumTitle.Text = result.AlbumTitle;

            base.OnNavigatedTo(e);

            Entrys = mc.getEntriesOverview(albumId);
        }

        // Click on an entry opens it in a new view
        private void GridView_ItemClick(object sender, ItemClickEventArgs e) {
            var entry = (Entry)e.ClickedItem;
            this.Frame.Navigate(typeof(Views.EntryView), new EntryParams() { EntryId = entry.EntryId, EntryTitle = entry.Title });
        }
        public class EntryParams {
            public int EntryId { get; set; }
            public String EntryTitle { get; set; }
        }


        // Open a new dialog to create a new entry an save them to the databse according to the album id
        private async void NewEntry_Click(object sender, RoutedEventArgs e) {
            AddEntry dialog = new AddEntry();
            var dialogResult = await dialog.ShowAsync();

            var Entry = new Entry();

            Entry.Title = dialog.Title;
            Entry.Description = dialog.Desc;

            mc.saveNewEntry(Entry, albumId);

        }

        // Deletes an album by id and changes view to AllAlbumsView
        private void deleteAlbum_Click(object sender, RoutedEventArgs e) {
            mc.deleteAlbum(albumId);
            this.Frame.Navigate(typeof(AllAlbumsView));
        }
    }
}
