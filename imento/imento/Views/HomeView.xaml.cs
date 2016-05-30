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
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls.Maps;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace imento
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomeView : Page
    {
        public HomeView()
        {
            this.InitializeComponent();
            MapIcon test = new MapIcon();
            add(48.604, -122.349, "fotoalbum2", test);

            Map.MapServiceToken = "0gUEEHhtil5mG0qB0tEX~an0v4B_f0lvb13FYhED-0Q~ArFoblBENhFwIE-Ku54MJ4wMek9cKVlMM4g2HiICGTaM9hHuLaukz-Ru3JGZxlWd";

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Map.Center = new Geopoint(new BasicGeoposition()
            {
                Latitude = 47.604,
                Longitude = -122.329
            });
            Map.ZoomLevel = 12;
            Map.LandmarksVisible = true;
            AddMapIcon();
        }
        private void AddMapIcon()
        {
            MapIcon MapIcon1 = new MapIcon();
            MapIcon1.Location = new Geopoint(new BasicGeoposition()
            {
                Latitude = 47.604,
                Longitude = -122.349
            });
            MapIcon1.NormalizedAnchorPoint = new Point(0.5, 1.0);
            MapIcon1.Title = "Fotoalbum 1";

            Map.MapElements.Add(MapIcon1);
        }

        private void add(double latitude, double longitude, string description, MapIcon x)
        {

            x.Location = new Geopoint(new BasicGeoposition()
            {
                Latitude = latitude,
                Longitude = longitude
            });
            x.NormalizedAnchorPoint = new Point(0.5, 1.0);
            x.Title = description;
            Map.MapElements.Add(x);
        }
    }
}
