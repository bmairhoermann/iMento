﻿using System;
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
using System.Collections.ObjectModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace imento
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FavsView : Page {

        ModelController mc = new ModelController();
        private ObservableCollection<PhotoViewModel> Photos;

        public FavsView() {
            this.InitializeComponent();

            fillObservableListWithPhotos();
        }

        private async void fillObservableListWithPhotos() {
            List<Photo> FavoritePhotos = mc.getFavouritePhotos();
            Photos = new ObservableCollection<PhotoViewModel>();

            foreach (Photo photo in FavoritePhotos) {
                var photoViewModel = new PhotoViewModel();
                photoViewModel.Photo = await photo.ToBitmapImage();
                photoViewModel.PhotoId = photo.PhotoId;
                Photos.Add(photoViewModel);
            }
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e) {
            var photo = (PhotoViewModel)e.ClickedItem;
            this.Frame.Navigate(typeof(Views.PhotoView), new PhotoParams() { PhotoId = photo.PhotoId });
        }
        public class PhotoParams {
            public int PhotoId { get; set; }
        }
    }
}
