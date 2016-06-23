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
        public string AlbumId { get; set; }
        public string AlbumTitle { get; set; }
        public string AlbumDescription { get; set; }
        public string AlbumType { get; set; }
        DateTime AlbumDate_Start { get; set; }
        DateTime AlbumDate_Ende { get; set; }

        public bool hasChanged { get; set; }

        public List<string> TypeList = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };

        // private bool IsNewAlbum = true;

        public ContentDialogMap(String location) {
            this.InitializeComponent();

            textBlockLocation1.Text = location;
            comboBox.PlaceholderText = "a";
        }
        public ContentDialogMap(String AlbumId, String AlbumTitle, String AlbumDescription, String AlbumType, DateTime AlbumDate_Start, DateTime AlbumDate_Ende) {
            this.InitializeComponent();

            textBoxName.Text = AlbumTitle;
            textBoxDescription.Text = AlbumDescription;

            // IsNewAlbum = false;
            this.AlbumId = AlbumId;
        }


        // Ok 
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args) {
            AlbumTitle = textBoxName.Text;
            AlbumDescription = textBoxDescription.Text;

            if (comboBox.SelectedIndex > -1) {
                AlbumType = (String)comboBox.SelectedItem;
            } else {
                comboBox.SelectedIndex = 0;
                AlbumType = (String)comboBox.SelectedItem;
            }

                System.Diagnostics.Debug.WriteLine("Speichern" + textBoxName.Text + textBoxDescription.Text + AlbumType);
            hasChanged = true;
        }

        // Cancel 
        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args) {
            System.Diagnostics.Debug.WriteLine("Abbrechen");
            hasChanged = false;

        }

    }
}

