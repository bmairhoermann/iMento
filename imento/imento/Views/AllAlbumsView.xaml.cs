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

namespace imento
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AllAlbumsView : Page {
        
        private List<Album> Albums;
        // public string ViewTitle = "Alle Alben xx";
        private Album album;

        ModelController mc = new ModelController();

        public AllAlbumsView() {
            this.InitializeComponent();
            
            Albums = mc.getAlbums();

            // mc.dostuff();
            // mc.saveNewAlbum(Album);
        }

        // Load EntryView an pass album data to load matching entries 
        private void GridView_ItemClick(object sender, ItemClickEventArgs e) {
            album = (Album)e.ClickedItem;
            this.Frame.Navigate(typeof(Views.AlbumView), new AlbumParams() { AlbumId = album.AlbumId, AlbumTitle = album.Title });
        }

        private void editAlbum_Click(object sender, RoutedEventArgs e) {
            
        }

        private void deleteAlbum_Click(object sender, RoutedEventArgs e) {
            
            Debug.WriteLine("-------------------");
            // Debug.WriteLine("Title: " + album.Title);
            Debug.WriteLine("-------------------");
            //mc.deleteAlbum();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }
    }
    public class AlbumParams {
        public String AlbumId { get; set; }
        public String AlbumTitle { get; set; }
    }
}
