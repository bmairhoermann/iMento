﻿using System;
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

namespace imento {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AllAlbumsView : Page {

        public String PageTitle = "Alle Alben";
        private List<Album> Albums;
        private Album album;
        ModelController mc = new ModelController();

        public AllAlbumsView() {
            this.InitializeComponent();
            Albums = mc.getAlbums();

            // Hide "No Album" infobox if albums exist in database 
            if (Albums.Count > 0) {
                NoAlbumsInfo.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Load AlbumView an pass album data to load matching entries 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">
        /// Gives information about the clicked item 
        /// </param>
        private void GridView_ItemClick(object sender, ItemClickEventArgs e) {
            album = (Album)e.ClickedItem;
            this.Frame.Navigate(typeof(Views.AlbumView), new AlbumParams() { AlbumId = album.AlbumId, AlbumTitle = album.Title, AlbumDescription = album.Description, AlbumType = album.Type, AlbumDate_Ende = album.Date_Ende, AlbumDate_Start = album.Date_Start });
        }
    }

    /// <summary>
    /// Params for the clicked album used to pass to the album view 
    /// </summary>
    public class AlbumParams {
        public String AlbumId { get; set; }
        public String AlbumTitle { get; set; }
        public String AlbumDescription { get; set; }
        public String AlbumType { get; set; }
        public DateTime AlbumDate_Start { get; set; }
        public DateTime AlbumDate_Ende { get; set; }
    }
}
