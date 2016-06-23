using System;
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

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace imento.Views {
    public sealed partial class AddEntry : ContentDialog {

        public string Title { get; set; }
        public string Desc { get; set; }
        public int Id { get; set; }

        public bool hasChanged { get; set; }

        public AddEntry() {
            this.InitializeComponent();
        }
        public AddEntry(string Title, string Desc, int Id) {
            this.InitializeComponent();
            this.Title = Title;
            this.Desc = Desc;
            this.Id = Id;
        }


        // Ok 
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args) {
            Title = textBoxTitle.Text;
            Desc = textBoxDescription.Text;

            hasChanged = true;
        }

        // Cancel 
        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args) {
            hasChanged = false;
        }
    }
}
