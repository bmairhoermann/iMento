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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace imento
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AllAlbumsView : Page {
        /*
        private List<Album> Albums;
        public string ViewTitle = "Alle Alben xx";
        */public AllAlbumsView() {
            this.InitializeComponent();
            /*
            // Data binding for albums
            Albums = AlbumManager.GetAlbums();*/
        }
        /*
        private void GridView_ItemClick(object sender, ItemClickEventArgs e) {
            var entry = (Album)e.ClickedItem;
            h1.Text = "You clicked on: " + entry.AlbumTitle;
        }
        */
    }
}
