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
    /// <summary>
    /// Implements Methods for Databaseinteraction
    /// </summary>
    class ModelController {

        /// <summary>
        /// Method for creating a TimeStamp
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String GetTimeStamp(DateTime value) {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        //################################################################################################################################
        //###########################################################GET_METHODS##########################################################
        //################################################################################################################################


        /// <summary>
        /// Get all Albums -> Returns an Album incuding Location
        /// </summary>
        /// <returns>List<Album></returns>
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


        /// <summary>
        /// Get Album with AlbumId -> Returns a Album including Location and excluding Entries
        /// </summary>
        /// <param name="AlbumId"></param>
        /// <returns>Album</returns>
        public Album getAlbum(String AlbumId) {
            Album Album = new Album();

            using (var db = new DataBaseContext()) {
                try {
                    Album = db.Albums.First(a => a.AlbumId == AlbumId);
                } catch {
                    Debug.WriteLine("MODELCONTROLLER: getAlbum(): Can not find Album!");
                }
                try {
                    Album.Location = db.Locations.First(l => l.AlbumId == AlbumId);
                } catch {
                    Debug.WriteLine("MODELCONTROLLER: getAlbum(): Can not find Location!");
                }
            }
            return Album;
        }

        /// <summary>
        /// Get Entries with one Photo using the current AlbumId -> Returns all Entries associated with the AlbumId but holds no photos
        /// </summary>
        /// <param name="AlbumId"></param>
        /// <returns>List<Entry></returns>
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

        /// <summary>
        /// Get one Entry with Photos using EntryID -> Returns a single Entry including the Photos it holds
        /// </summary>
        /// <param name="EntryID"></param>
        /// <returns>Entry</returns>
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

        /// <summary>
        /// Get Photo with PhotoId
        /// </summary>
        /// <param name="PhotoId"></param>
        /// <returns>Photo</returns>
        public Photo getPhoto(int PhotoId) {
            Photo photo = new Photo();

            using (var db = new DataBaseContext()) {
                try {
                    photo = db.Photos.First(p => p.PhotoId == PhotoId);
                } catch {
                    Debug.WriteLine("MODELCONTROLLER: getPhoto: No Photo found!");
                }
            }
            return photo;
        }

        /// <summary>
        /// Get List of Photos that are marked as favourites
        /// </summary>
        /// <returns>List<Photo></returns>
        public List<Photo> getFavouritePhotos() {
            List<Photo> photoList = new List<Photo>();
            using (var db = new DataBaseContext()) {
                try {
                    photoList = db.Photos.Where(p => p.isFavourite == true).ToList();
                } catch {
                    Debug.WriteLine("MODELCONTROLLER: getFavouritePhotos: Not able to find Photos in Database!");
                }
            }
            return photoList;
        }

        //################################################################################################################################
        //###########################################################ADD_METHODS##########################################################
        //################################################################################################################################

        /// <summary>
        /// Add Album to Database
        /// </summary>
        /// <param name="Album"></param>
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

        /// <summary>
        /// Add Entry with AlbumId to Database
        /// </summary>
        /// <param name="Entry"></param>
        /// <param name="AlbumId"></param>
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

        /// <summary>
        /// Add Photo with EntryId to Database
        /// </summary>
        /// <param name="Photo"></param>
        /// <param name="EntryId"></param>
        public void saveNewPhoto(Photo Photo, int EntryId) {
            using (var db = new DataBaseContext()) {
                try {
                    Photo.EntryId = EntryId;
                    db.Photos.Add(Photo);
                    db.SaveChanges();
                } catch {
                    Debug.WriteLine("MODELCONTROLLER: saveNewPhoto(): Not able to add Photo to Database!");
                }
            }
        }

        //################################################################################################################################
        //###########################################################UPDATE_METHODS#######################################################
        //################################################################################################################################

        /// <summary>
        /// Update Album in Database
        /// </summary>
        /// <param name="Album"></param>
        public void updateAlbumInfo(Album Album) {
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

        /// <summary>
        /// Update Entry in Database
        /// </summary>
        /// <param name="Entry"></param>
        public void updateEntry(Entry Entry) {
            using (var db = new DataBaseContext()) {
                try {
                    db.Entries.Update(Entry);
                    db.SaveChanges();
                } catch {
                    Debug.WriteLine("MODELCONTROLLER: upateEntry(): Not able to update Entry in Database!");
                }
            }
        }

        /// <summary>
        /// Update Location in Database
        /// </summary>
        /// <param name="Location"></param>
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

        /// <summary>
        /// Update Photo in Database
        /// </summary>
        /// <param name="photoId"></param>
        /// <param name="isFavourite"></param>
        public void updatePhoto(int photoId, bool isFavourite) {
            using (var db = new DataBaseContext()) {
                try {
                    Photo photo = db.Photos.First(p => p.PhotoId == photoId);
                    photo.isFavourite = isFavourite;
                    db.Photos.Update(photo);
                    db.SaveChanges();
                } catch {
                    Debug.WriteLine("MODELCONTROLLER: updatePhoto(): Not able to update Photo in Database!");
                }
            }
        }


        //################################################################################################################################
        //###########################################################DELETE_METHODS#######################################################
        //################################################################################################################################

        /// <summary>
        /// Delete Album with AlbumId in Database
        /// </summary>
        /// <param name="AlbumId"></param>
        public void deleteAlbum(string AlbumId) {
            Album Album = new Album();
            using (var db = new DataBaseContext()) {
                try {
                    Album = db.Albums.First(a => a.AlbumId == AlbumId);
                } catch {
                    Debug.WriteLine("MODELCONTROLLER: deleteAlbum(): Not able to find Album in Database!");
                }
                try {
                    Album.Location = db.Locations.First(l => l.AlbumId == AlbumId);
                } catch {
                    Debug.WriteLine("MODELCONTROLLER: deleteAlbum(): Not able to find Location in Database!");
                }
                try {
                    var Entries = db.Entries.Where(e => e.AlbumId == AlbumId).ToList();
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

        /// <summary>
        /// Delete Entry in Database
        /// </summary>
        /// <param name="EntryId"></param>
        public void deleteEntry(int EntryId) {
            using (var db = new DataBaseContext()) {
                Entry Entry = new Entry();
                try {
                    Entry = db.Entries.First(e => e.EntryId == EntryId);
                } catch {
                    Debug.WriteLine("MODELCONTROLLER: deleteEntry(): Not able to find Entry in Database!");
                }
                try {
                    Entry.Photos = db.Photos.Where(p => p.EntryId == EntryId).ToList();
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

        /// <summary>
        /// Delete Photo in Database
        /// </summary>
        /// <param name="PhotoId"></param>
        public void deletePhoto(int PhotoId) {
            var Photo = new Photo();
            using (var db = new DataBaseContext()) {
                try {
                    Photo = db.Photos.First(p => p.PhotoId == PhotoId);
                } catch {
                    Debug.WriteLine("MODELCONTROLLER: deletePhoto(): Not able to find Photo in Database!");
                }
                try {
                    db.Remove(Photo);
                    db.SaveChanges();
                } catch {
                    Debug.WriteLine("MODELCONTROLLER: deletePhoto(): Not able to delete Photo in Database!");
                }
            }
        }
    }
}
