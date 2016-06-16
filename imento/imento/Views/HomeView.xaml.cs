using System;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls.Maps;
using Windows.Services.Maps;
using System.Linq;
using Windows.UI.Xaml;
using System.ServiceModel.Channels;
using Windows.UI.Xaml.Data;
using imento.Views;
using imento.Models;
using System.Diagnostics;
using System.Collections.Generic;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace imento
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomeView : Page
    {
        MapIcon current = new MapIcon();
        ModelController mc = new ModelController();
        Dictionary<MapIcon, string> mapIconDictionary = new Dictionary<MapIcon, string>();


        public HomeView() {

          //  mc.getAlbums();
            foreach (var e in mc.getAlbums())
            {
                MapIcon startIcons = new MapIcon();
                add(e.Location.Latitude, e.Location.Longitude, e.Title, startIcons);
                mapIconDictionary.Add(startIcons, e.AlbumId);
                }   
            this.InitializeComponent();
 
            Map.MapServiceToken = "0gUEEHhtil5mG0qB0tEX~an0v4B_f0lvb13FYhED-0Q~ArFoblBENhFwIE-Ku54MJ4wMek9cKVlMM4g2HiICGTaM9hHuLaukz-Ru3JGZxlWd";
        }

        //Zoom-Level 

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            Map.ZoomLevel = 2;
            Map.LandmarksVisible = true;
        }


        private async void add(double latitude, double longitude, string title, MapIcon x) {
            x.Location = new Geopoint(new BasicGeoposition() {
                Latitude = latitude,
                Longitude = longitude
            });
            x.NormalizedAnchorPoint = new Point(0.5, 1.0);
            x.Title = title;


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
                x.Title = title + " aus " + result.Locations[0].Address.Town;
            }
            Map.MapElements.Add(x);
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
            if (result.Status == MapLocationFinderStatus.Success) {
                current = MapIcon1;

                ContentDialogMap dialog = new ContentDialogMap(result.Locations[0].Address.Town);
                var dialogResult = await dialog.ShowAsync();
                if (dialogResult == ContentDialogResult.Primary) {

                    // zum testen
                    MapIcon1.Title = dialog.Name;
                    Map.MapElements.Add(MapIcon1);


                    // Create new Album and Location and save in the database
                    
                    
                    // Create Loaction
                    var Location = new Location();
                    Location.Description = result.Locations[0].Address.Town;
                    Location.Longitude = MapIcon1.Location.Position.Longitude;
                    Location.Latitude = MapIcon1.Location.Position.Latitude;

                    // Create Album
                    var Album = new Album();

                    // IMPORTANT: SET ALBUMID WHEN CREATING NEW ALBUM
                    Album.AlbumId = ModelController.GetTimeStamp(DateTime.Now);

                    Album.Title = dialog.Name;
                    Album.Description = dialog.Desc;
                    Album.Type = "Rundreise"; // ??? 
                    Album.Date_Start = new DateTime(2015, 1, 7); // ??? 
                    Album.Date_Ende = new DateTime(2015, 1, 10); // ??? 
                    Album.Location = Location;
                    // Album.Entries = EntryList;

                    mc.saveNewAlbum(Album);
                    
                }
            }
        }


        private void Map_MapElementClick(MapControl sender, MapElementClickEventArgs args) {
            string albumID;

            foreach (var e in args.MapElements)
            {
                if (e is MapIcon)
                {
                    var icon = e as MapIcon;

                    if (mapIconDictionary.ContainsKey(icon))
                    {
                        if (mapIconDictionary.TryGetValue(icon, out albumID))
                        {
                            System.Diagnostics.Debug.WriteLine("Mapicon wurde gedrückt " + albumID);
                            this.Frame.Navigate(typeof(Views.AlbumView), new AlbumParams() { AlbumId = albumID, AlbumTitle = icon.Title });
                        }
                    }
                }
            }
        }
    }
}
