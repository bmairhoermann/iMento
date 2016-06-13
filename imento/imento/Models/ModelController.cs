using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.Storage.Streams;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Diagnostics;
using Windows.UI.Xaml.Media.Imaging;
using System.IO;

namespace imento.Models {
    class ModelController {
        // Method for creating a TimeStamp
        public static String GetTimeStamp(DateTime value) {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        // Method for Parsing a byte-Array to a BitmapImage
        public async Task<BitmapImage> ToBitmapImage(byte[] array) {
            using (var ms = new MemoryStream(array)) {
                var bitmapImage = new BitmapImage();
                await bitmapImage.SetSourceAsync(ms.AsRandomAccessStream());
                return bitmapImage;
            }
        }

        //################################################################################################################################
        //###########################################################GET_METHODS##########################################################
        //################################################################################################################################

        // Get all Albums -> Returns an Album incuding Location
        public List<Album> getAlbums() {
            // Create empty AlbumList
            List<Album> albums = new List<Album>();

            // Get All Albums without further values (such as Entries) exept for Location
            using (var db = new DataBaseContext()) {
                albums = db.Albums.ToList();


                // Get Location via AlbumId
                foreach (Album album in albums) {
                    var location = new Location();
                    try {
                        location = db.Locations.First(l => l.AlbumId == album.AlbumId);
                    } catch { }

                    if (location.LocationId == 0) {
                        Debug.WriteLine("MODELCONTROLLER: getAlbums(): Location is empty!");
                    } else {
                        album.Location = location;
                    }
                }
            }
            return albums;
        }

        // Get Entries with one Photo using the current AlbumId -> Returns all Entries associated with the AlbumId but holds no photos
        public List<Entry> getEntriesOverview(string AlbumId) {
            // Create empty EntryList
            List<Entry> entries = new List<Entry>();

            // Get Entries via AlbumId

            try {
                using (var db = new DataBaseContext()) {
                    var tmp = db.Entries.Where(e => e.AlbumId == AlbumId);
                    var dbEntries = tmp.ToList();

                    // Put first Photo of the Entry-Photo-List into the Entry
                    foreach (Entry entry in dbEntries) {
                        var dbPhoto = new Photo();
                        try {
                            dbPhoto = db.Photos.First(p => p.EntryId == entry.EntryId);
                        } catch { }

                        if (dbPhoto.PhotoId == 0) {
                            Debug.WriteLine("MODELCONTROLLER: getEntriesOverview: Photos are emtpy!");
                        } else {
                            entry.Photos.Add(dbPhoto);
                        }
                    }
                    entries = dbEntries;
                }
            } catch {
                Debug.WriteLine("MODELCONTROLLER: getEntriesOverView: No Entry with given EntryId found!");
            }
            return entries;
        }

        // Get one Entry with Photos using EntryID -> Returns a single Entry including the Photos it holds
        public Entry getEntryDetails(int EntryID) {
            // Create empty Entry-Oject
            Entry entry = new Entry();

            // Get Entry-Element via EntryID
            using (var db = new DataBaseContext()) {
                var dbEntry = new Entry();
                try {
                    dbEntry = db.Entries.First(e => e.EntryId == EntryID);
                } catch { }

                if (dbEntry.EntryId == 0) {
                    Debug.WriteLine("MODELCONTROLLER: getEntryDetails: No Entries found!");
                } else {
                    // Fill Photos of Entry-Object
                    List<Photo> dbPhotos = new List<Photo>();
                    try {
                        var tmpDbPhotos = db.Photos.Where(p => p.EntryId == dbEntry.EntryId);
                        var photoList = tmpDbPhotos.ToList();
                        dbEntry.Photos = photoList;
                    } catch {
                        Debug.WriteLine("MODELCONTROLLER: getEntryDetails: No Photos found!");
                    }
                    entry = dbEntry;
                }
            }
            return entry;
        }

        //################################################################################################################################
        //###########################################################ADD_METHODS##########################################################
        //################################################################################################################################

        // Add Album to Database
        public void saveNewAlbum(Album Album) {
            using (var db = new DataBaseContext()) {
                try {
                    db.Albums.Add(Album);
                    db.SaveChanges();
                } catch {
                    Debug.WriteLine("MODELCONTROLLER: saveNewAlbum(): Not able to add Album to Database!");
                }
            }

        }

        // Add Entry with AlbumId to Database
        public void saveNewEntry(Entry Entry, string AlbumId) {
            using (var db = new DataBaseContext()) {
                try {
                    Entry.AlbumId = AlbumId;
                    db.Entries.Add(Entry);
                    db.SaveChanges();
                } catch {
                    Debug.WriteLine("MODELCONTROLLER: saveNewEntry(): Not able to add Entry to Database!");
                }
            }
        }

        //################################################################################################################################
        //###########################################################UPDATE_METHODS#######################################################
        //################################################################################################################################

        // Update Album in Database
        public void updateAlbum(Album Album) {
            using (var db = new DataBaseContext()) {
                try {
                    Album.Location = db.Locations.First(l => l.AlbumId == Album.AlbumId);
                } catch {
                    Debug.WriteLine("MODELCONTROLLER: updateAlbum(): Not able to find Location in Database!");
                }
                try {
                    var Entries = db.Entries.Where(e => e.AlbumId == Album.AlbumId).ToList();
                    foreach (Entry entry in Entries) {
                        entry.Photos = db.Photos.Where(p => p.EntryId == entry.EntryId).ToList();
                    }
                    Album.Entries = Entries;
                } catch {
                    Debug.WriteLine("MODELCONTROLLER: updateAlbum(): Not able to find Entries in Database!");
                }
                try {
                    db.Albums.Update(Album);
                    db.SaveChanges();
                } catch {
                    Debug.WriteLine("MODELCONTROLLER: updateAlbum(): Not able to update Album in Database!");
                }
            }
        }

        // Update Entry in Database
        public void updateEntry(Entry Entry) {
            using (var db = new DataBaseContext()) {
                try {
                    Entry.Photos = db.Photos.Where(p => p.EntryId == Entry.EntryId).ToList();
                } catch {
                    Debug.WriteLine("MODELCONTROLLER: updateEntry(): Not able to find Photos in Database!");
                }
                try {
                    db.Entries.Update(Entry);
                    db.SaveChanges();
                } catch {
                    Debug.WriteLine("MODELCONTROLLER: upateEntry(): Not able to update Entry in Database!");
                }
            }
        }

        // Update Location in Database
        public void updateLocation(Location Location) {
            using (var db = new DataBaseContext()) {
                try {
                    db.Locations.Update(Location);
                    db.SaveChanges();
                } catch {
                    Debug.WriteLine("MODELCONTROLLER: updateLocation(): Not able to update Location in Database!");
                }
            }
        }

        //################################################################################################################################
        //###########################################################DELETE_METHODS#######################################################
        //################################################################################################################################

        // Delete Album in Database
        public void deleteAlbum(Album Album) {
            using (var db = new DataBaseContext()) {
                try {
                    Album.Location = db.Locations.First(l => l.AlbumId == Album.AlbumId);
                } catch {
                    Debug.WriteLine("MODELCONTROLLER: deleteAlbum(): Not able to find Location in Database!");
                }
                try {
                    var Entries = db.Entries.Where(e => e.AlbumId == Album.AlbumId).ToList();
                    foreach (Entry entry in Entries) {
                        entry.Photos = db.Photos.Where(p => p.EntryId == entry.EntryId).ToList();
                    }
                    Album.Entries = Entries;
                } catch {
                    Debug.WriteLine("MODELCONTROLLER: deleteAlbum(): Not able to find Entries in Database!");
                }
                try {
                    db.Remove(Album);
                    db.SaveChanges();
                } catch {
                    Debug.WriteLine("MODELCONTROLLER: deleteAlbum(): Not able to delete Album in Database!");
                }
            }
        }

        // Delete Entry in Database
        public void deleteEntry(Entry Entry) {
            using (var db = new DataBaseContext()) {
                try {
                    Entry.Photos = db.Photos.Where(p => p.EntryId == Entry.EntryId).ToList();
                } catch {
                    Debug.WriteLine("MODELCONTROLLER: deleteEntry(): Not able to find Photos in Database!");
                }
                try {
                    db.Remove(Entry);
                    db.SaveChanges();
                } catch {
                    Debug.WriteLine("MODELCONTROLLER: deleteAlbum(): Not able to delete Entry in Database!");
                }
            }
        }


        // +++++++++++++++++++++++++++++++++++++
        // EXAMPLE CODE
        // +++++++++++++++++++++++++++++++++++++

        public async void dostuff() {
            /*
            // CREATING AN ALBUM WITH ALL SUBOBJECTS
            
            using (var db = new DataBaseContext())
            {

                var tmpPhotoPaths = new String[] { "pic01.jpg", "pic02.jpg", "pic03.jpg" };

                //Create Photo List
                List<Photo> Photos = new List<Photo>();

                var storageFolder = Package.Current.InstalledLocation; //Installationsordner
                storageFolder = await storageFolder.GetFolderAsync("Pictures"); //Assets-Ordner

                foreach (string item in tmpPhotoPaths)
                {
                    var photo = new Photo();

                    var picFile = await storageFolder.GetFileAsync(item); //Datei
                    IBuffer buffer = await FileIO.ReadBufferAsync(picFile); //Einlesen

                    byte[] imgArray = buffer.ToArray();

                    photo.ImageByteArray = imgArray;

                    Photos.Add(photo);

                }


                // Create Entry-List
                List<Entry> EntryList = new List<Entry>();

                var Entry1 = new Entry();

                Entry1.Date = new DateTime(2015, 1, 8);
                Entry1.Title = "Testeintrag 1";
                Entry1.Description = "Lorem ipsum dolor sit amet, consequentur in argante pater sufus.";
                Entry1.Photos = Photos;
                EntryList.Add(Entry1);

                var Entry2 = new Entry();
                Entry2.Date = new DateTime(2015, 1, 9);
                Entry2.Title = "Testeintrag 2";
                Entry2.Description = "Lorem ipsum dolor sit amet, consequentur in argante pater sufus.";
                Entry2.Photos = Photos;
                EntryList.Add(Entry1);

                // Create Loaction
                var Location = new Location();
                Location.Description = "Palma de Mallorca";
                Location.Longitude = 39.5698686;
                Location.Latitude = 2.540671;

                // Create Album
                var Album = new Album();

                // IMPORTANT: SET ALBUMID WHEN CREATING NEW ALBUM
                Album.AlbumId = GetTimeStamp(DateTime.Now);

                Album.Title = "Barcelona";
                Album.Description = "Lorem ipsum dolor.";
                Album.Type = "Rundreise";
                Album.Date_Start = new DateTime(2015, 1, 7);
                Album.Date_Ende = new DateTime(2015, 1, 10);
                Album.Location = Location;
                Album.Entries = EntryList;



                // Put Album with Entries in Table
                db.Albums.Add(Album);

                // Save Changes on Table
                db.SaveChanges();
            }
            */

            // PRINTING ATTRIBUTES OF ITEMS IN DATABASE

            Debug.WriteLine("BEFOR OUTPUT OF TABLE");

            using (var db = new DataBaseContext()) {
                var myAlbum = from item in db.Albums select item;
                foreach (Album item in myAlbum) {
                    Debug.WriteLine("Album ID: " + item.AlbumId);
                    Debug.WriteLine(item.Title);
                    Debug.WriteLine(item.Description);
                    Debug.WriteLine("");




                }

                var myEntries1 = from item in db.Entries select item;
                {
                    foreach (Entry item in myEntries1) {
                        Debug.WriteLine(item.Title);
                        Debug.WriteLine("Foreign Key ALBUM_ID: " + item.AlbumId);
                    }
                }
            }


        }
    }
}
