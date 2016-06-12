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


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace imento.Views {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EntryView : Page {

        private List<Photo> Photos;
        private Entry currentEntry = new Entry();

        private List<ImageSource> PicSource;

        public String albumId;
        public int entryId;
        ModelController mc = new ModelController();

        public EntryView() {
            this.InitializeComponent();
            // mc.dostuff();
        }

        // If AlbumId is passed, it will be set to the String albumId
        protected override async void OnNavigatedTo(NavigationEventArgs e) {
            EntryParams result = (EntryParams)e.Parameter;

            entryId = result.EntryId;
            // EntryTitle.Text = result.AlbumTitle;

            base.OnNavigatedTo(e);

            currentEntry = mc.getEntryDetails(entryId);

            Photos = currentEntry.Photos;
            /*
            foreach(var item in Photos) {
                var bitMapImage = await mc.ToBitmapImage(item.ImageByteArray);
                ImageSource imageSource = bitMapImage;
                PicSource.Add(imageSource);
            }
             */  

            
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e) {

        }

        private async void NewPhoto_Click(object sender, RoutedEventArgs e) {
            AddPhoto dialog = new AddPhoto(entryId);
            var dialogResult = await dialog.ShowAsync();
        }

    }
}



