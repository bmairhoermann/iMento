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
using imento.Models;
using Windows.UI.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace imento
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page {

        public MainPage() {
            this.InitializeComponent();
            // Set the Main View
            MainFrame.Navigate(typeof(HomeView));
            // Overwrite the default minimum size settings for the window
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(200, 100));
            // Disable Back Button
            GoBack.Visibility = Visibility.Collapsed;
        }

        // OpenMainMenu: Opens or closes the main menu
        private void OpenMainMenu(object sender, RoutedEventArgs e) {
            MainSV.IsPaneOpen = !MainSV.IsPaneOpen;
        }

        // ListBox_SelectionChanged: Changes view according to the pressed button 
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            GoBack.Visibility = Visibility.Visible;
            if (Home.IsSelected) {
                MainFrame.Navigate(typeof(HomeView));
                Title.Text = "Startseite";
                GoBack.Visibility = Visibility.Collapsed;
            } else if (NewAlbum.IsSelected) {
                MainFrame.Navigate(typeof(Views.EntryView)); // wtf...
                Title.Text = "Neues Album anlegen";
            } else if (AllAlbums.IsSelected) {
                MainFrame.Navigate(typeof(AllAlbumsView));
                Title.Text = "Alle Alben";
            } else if (Favs.IsSelected) {
                MainFrame.Navigate(typeof(FavsView));
                Title.Text = "Meine Favoriten";
            } else if (Settings.IsSelected) {
                MainFrame.Navigate(typeof(SettingsView));
                Title.Text = "Einstellungen";
            } else if (Help.IsSelected){
                MainFrame.Navigate(typeof(HelpView));
                Title.Text = "Hilfe und Kurzanleitung";
            } else if (About.IsSelected) {
                MainFrame.Navigate(typeof(AboutView));
                Title.Text = "Über diese App";
            }
        }
        private void GoBack_Click(object sender, RoutedEventArgs e) {
            if (MainFrame.CanGoBack) {
                MainFrame.GoBack();
                Title.Text = "Zurück gegangen";
            } else {
                GoBack.Visibility = Visibility.Collapsed;
            }
        }
    }
}
