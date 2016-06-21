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
using Windows.Storage.Streams;

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
                add(e.Location.Latitude, e.Location.Longitude, e.Title, startIcons, e.Type);
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


        private async void add(double latitude, double longitude, string title, MapIcon x, string type) {
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
            System.Diagnostics.Debug.WriteLine("Mapicon LOADING " + type);
            x.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/icons/icon_"+ type +".png"));
           
            Map.MapElements.Add(x);
        }



        private async void Map_MapHolding(MapControl sender, MapInputEventArgs e)
        {
            MapIcon tempMapIcon = new MapIcon();
            tempMapIcon.Location = new Geopoint(new BasicGeoposition()
            {
                Latitude = e.Location.Position.Latitude,
                Longitude = e.Location.Position.Longitude
            });
            tempMapIcon.NormalizedAnchorPoint = new Point(0.5, 1.0);


            BasicGeoposition geoPosition = new BasicGeoposition();
            geoPosition.Latitude = e.Location.Position.Latitude;
            geoPosition.Longitude = e.Location.Position.Longitude;

            // Reverse geocode the specified geographic location.
            Geopoint pointToReverseGeocode = new Geopoint(geoPosition);

            
            MapLocationFinderResult result = await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);

            // If the query returns results, display the name of the town
            // contained in the address of the first result.
            if (result.Status == MapLocationFinderStatus.Success) {
                current = tempMapIcon;

                ContentDialogMap dialog = new ContentDialogMap(result.Locations[0].Address.Town);
                var dialogResult = await dialog.ShowAsync();
                if (dialogResult == ContentDialogResult.Primary) {

                    // zum testen
                    tempMapIcon.Title = dialog.AlbumTitle;

                    tempMapIcon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/icons/icon_" + dialog.AlbumType + ".png"));
                    Map.MapElements.Add(tempMapIcon);


                    // Create new Album and Location and save in the database
                    
                    
                    // Create Loaction
                    var Location = new Location();
                    Location.Description = result.Locations[0].Address.Town;
                    Location.Longitude = tempMapIcon.Location.Position.Longitude;
                    Location.Latitude = tempMapIcon.Location.Position.Latitude;

                    // Create Album
                    var Album = new Album();

                    // IMPORTANT: SET ALBUMID WHEN CREATING NEW ALBUM
                    Album.AlbumId = ModelController.GetTimeStamp(DateTime.Now);

                    Album.Title = dialog.AlbumTitle;
                    Album.Description = dialog.AlbumDescription;
                    Album.Type = dialog.AlbumType;  
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
