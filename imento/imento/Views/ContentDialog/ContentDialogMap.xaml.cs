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
    public sealed partial class ContentDialogMap : ContentDialog
    {
        public ContentDialogMap(String location)
        {

            this.InitializeComponent();

            textBlockLocation1.Text = location;
            TypeList = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h","i","j" };
        }

        public string Name { get; set; }
        public string Desc { get; set; }
        public string Type { get; set; }

        public List<string> TypeList { get; set; }

        // Ok 
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args) {
            Name = textBoxName.Text;
            Desc = textBoxDescription.Text;
            Type = (String)comboBox.SelectedItem;

            System.Diagnostics.Debug.WriteLine("Speichern"+ textBoxName.Text + textBoxDescription.Text + Type);


        }


        // Cancel 
        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args) {
            System.Diagnostics.Debug.WriteLine("Abbrechen");
        }

    }
}

