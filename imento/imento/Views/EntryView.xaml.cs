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
    /// 


    public sealed partial class EntryView : Page {

        private List<Entry> Entrys;
        ModelController mc = new ModelController();

        // zum testen
        public String albumId = "201606081559089693";


        public EntryView() {
            this.InitializeComponent();
            // mc.dostuff();
        }

        // If AlbumId is passed, it will be set to the String albumId
        protected override void OnNavigatedTo(NavigationEventArgs e) {
            String result = (String)e.Parameter;
            albumId = (String)e.Parameter;
            base.OnNavigatedTo(e);

            Entrys = mc.getEntriesOverview(albumId);
        }


        private void GridView_ItemClick(object sender, ItemClickEventArgs e) {

        }
    }
}
