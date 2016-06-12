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
        }

        public string Name { get; set; }

        // Ok 
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args) {
            Name = textBoxName.Text;
            //   System.Diagnostics.Debug.WriteLine("Speichern"+ textBoxName.Text + textBoxDescription.Text + ComboBox.SelectedItemProperty);


        }


        // Cancel 
        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args) {
            System.Diagnostics.Debug.WriteLine("Abbrechen");
        }

    }
}

