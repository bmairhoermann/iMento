using imento.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// Die Elementvorlage "Inhaltsdialog" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace imento.Views
{
    public sealed partial class ContentDialogMap : ContentDialog {
        public Album album { get; set; }
        public string AlbumId { get; set; }
        public string AlbumTitle { get; set; }
        public string AlbumDescription { get; set; }
        public string AlbumType { get; set; }
        DateTime AlbumDate_Start { get; set; }
        DateTime AlbumDate_Ende { get; set; }

        public bool hasChanged { get; set; }

        public ObservableCollection<string> TypeList = new ObservableCollection<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
        

        public ContentDialogMap(String location) {
            this.InitializeComponent();

            album = new Album();
            textBlockLocation1.Text = location;
            comboBox.ItemsSource = TypeList;
            comboBox.SelectedIndex = 0;
        }
        public ContentDialogMap(Album album) {
            this.InitializeComponent();
            this.album = album;
            try {
                textBoxName.Text = album.Title;
                textBoxDescription.Text = album.Description;
                comboBox.PlaceholderText = album.Type;
            } catch { }
        }


        // Ok 
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args) {
            
            album.Title = textBoxName.Text;
            album.Description = textBoxDescription.Text;
            album.Date_Start = startDate.Date.Value.Date;
            
            album.Date_Ende = endDate.Date.Value.Date;

            if (comboBox.SelectedIndex < 0){
                album.Type = (String)comboBox.PlaceholderText;
            } else {
                album.Type = (String)comboBox.SelectedItem;
            }
            
           
            hasChanged = true;
        }

        // Cancel 
        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args) {
            hasChanged = false;

        }

    }
}

