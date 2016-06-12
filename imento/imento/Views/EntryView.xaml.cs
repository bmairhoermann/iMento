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
    public sealed partial class EntryView : Page {

        // private List<Entry> Entrys;
        public String albumId;
        ModelController mc = new ModelController();

        public EntryView() {
            this.InitializeComponent();
            // mc.dostuff();
        }

        // If AlbumId is passed, it will be set to the String albumId
        protected override void OnNavigatedTo(NavigationEventArgs e) {
            // String result = (String)e.Parameter;
            // AlbumParams result = (AlbumParams)e.Parameter;
            
            //albumId = result.AlbumId;
            // EntryTitle.Text = result.AlbumTitle;

            base.OnNavigatedTo(e);

            // Entrys = mc.getEntriesOverview(albumId);
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e) {

        }

        private async void NewPhoto_Click(object sender, RoutedEventArgs e) {
            AddPhoto dialog = new AddPhoto();
            var dialogResult = await dialog.ShowAsync();

            /*
           
            if (dialogResult == ContentDialogResult.Primary) {
                MapIcon1.Title = dialog.Name;

                Map.MapElements.Add(MapIcon1);

            }
            */
        }

    }
}



