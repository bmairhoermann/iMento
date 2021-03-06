﻿using imento.Models;
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

        public Entry entry { get; set; }

        public bool hasChanged { get; set; }

        public AddEntry() {
            this.InitializeComponent();
        }
        public AddEntry(Entry entry) {
            this.InitializeComponent();
            this.entry = entry;

            if(entry.Title != null) {
                textBoxTitle.Text = entry.Title;
            }
            if(entry.Description != null) {
                textBoxDescription.Text = entry.Description;
            }
        }


        // Ok 
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args) {
            entry.Title = textBoxTitle.Text;
            entry.Description = textBoxDescription.Text;

            hasChanged = true;
        }

        // Cancel 
        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args) {
            hasChanged = false;
        }
    }
}
