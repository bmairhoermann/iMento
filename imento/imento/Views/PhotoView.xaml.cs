using imento.Models;
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
using static imento.Views.EntryView;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace imento.Views {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PhotoView : Page {

        ModelController mc = new ModelController();
        Photo photo = new Photo();


        public PhotoView() {
            this.InitializeComponent();
        }
        


        protected override async void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);

            PhotoParams result = (PhotoParams)e.Parameter;

            photo = mc.getPhoto(result.PhotoId);

            ImageSource imageSource = await photo.ToBitmapImage();
            DisplayPhoto.Source = imageSource;

        }



    }
}
