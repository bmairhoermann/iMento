using System;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls.Maps;
using Windows.Services.Maps;
using imento.Models;
using System.Diagnostics;
using System.Linq;

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
            MapIcon test1 = new MapIcon();
            
            add(48.604, -122.349, "Fotoalbum123", test);
            add(48.604, -222.349, "Fotoalbum 2", test1);
            

            Map.MapServiceToken = "0gUEEHhtil5mG0qB0tEX~an0v4B_f0lvb13FYhED-0Q~ArFoblBENhFwIE-Ku54MJ4wMek9cKVlMM4g2HiICGTaM9hHuLaukz-Ru3JGZxlWd";

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            /*
            Map.Center = new Geopoint(new BasicGeoposition()
            {
                Latitude = 47.604,
                Longitude = -122.329
            });
            */
            Map.ZoomLevel = 2;
            Map.LandmarksVisible = true;
            
        }
        /*  private void AddMapIcon()
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
          */

        private async void add(double latitude, double longitude, string description, MapIcon x)
        {
            string neu2 = description;

            //MapIcon x = new MapIcon();

            x.Location = new Geopoint(new BasicGeoposition()
            {
                Latitude = latitude,
                Longitude = longitude
            });
            x.NormalizedAnchorPoint = new Point(0.5, 1.0);
            x.Title = description ;
            
            

            BasicGeoposition location = new BasicGeoposition();
            location.Latitude = latitude;
            location.Longitude = longitude;
            Geopoint pointToReverseGeocode = new Geopoint(location);

            // Reverse geocode the specified geographic location.
            MapLocationFinderResult result =
                await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);

            // If the query returns results, display the name of the town
            // contained in the address of the first result.
            if (result.Status == MapLocationFinderStatus.Success)
            {
              //  tbOutputText.Text = "Stadt = " + result.Locations[0].Address.Town;
                x.Title = description + " aus " + result.Locations[0].Address.Town;
            }
            Map.MapElements.Add(x);
        }
        private async void Geocode()
        {
            // Address or business to geocode.
            string addressToGeocode = "Microsoft";

            // Nearby location to use as a query hint.
            BasicGeoposition queryHint = new BasicGeoposition();
            queryHint.Latitude = 47.643;
            queryHint.Longitude = -122.131;
            Geopoint hintPoint = new Geopoint(queryHint);

            // Geocode the specified address, using the specified reference point
            // as a query hint. Return no more than 3 results.
            MapLocationFinderResult result =
                await MapLocationFinder.FindLocationsAsync(
                                    addressToGeocode,
                                    hintPoint,
                                    3);

            // If the query returns results, display the coordinates
            // of the first result.
            if (result.Status == MapLocationFinderStatus.Success)
            {
                tbOutputText.Text = "result = (" +
                    result.Locations[0].Point.Position.Latitude.ToString() + "," +
                    result.Locations[0].Point.Position.Longitude.ToString() + ")";
            }
        }


        private async void Map_MapHolding(MapControl sender, MapInputEventArgs e)
        {
            MapIcon MapIcon1 = new MapIcon();
            MapIcon1.Location = new Geopoint(new BasicGeoposition()
            {
                Latitude = e.Location.Position.Latitude,
                Longitude = e.Location.Position.Longitude
            });
            MapIcon1.NormalizedAnchorPoint = new Point(0.5, 1.0);
          

            BasicGeoposition location = new BasicGeoposition();
            location.Latitude = e.Location.Position.Latitude;
            location.Longitude = e.Location.Position.Longitude;
            Geopoint pointToReverseGeocode = new Geopoint(location);

            // Reverse geocode the specified geographic location.
            MapLocationFinderResult result = await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);

            // If the query returns results, display the name of the town
            // contained in the address of the first result.
            if (result.Status == MapLocationFinderStatus.Success)
            {
                //  tbOutputText.Text = "Stadt = " + result.Locations[0].Address.Town;
                MapIcon1.Title = "Neues Fotoalbum aus " + result.Locations[0].Address.Town;
            }
            Map.MapElements.Add(MapIcon1);
        }
    }
}
