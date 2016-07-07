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
using imento.Views;

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

            // Handle the GoBack Button in the Title Bar or the Button on Windows Phones 
            var systemNavigationManager = SystemNavigationManager.GetForCurrentView();
            systemNavigationManager.BackRequested += SystemNavigationManagerOnBackRequested;
            systemNavigationManager.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }

        /// <summary>
        /// Opens or closes the main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenMainMenu(object sender, RoutedEventArgs e) {
            MainSV.IsPaneOpen = !MainSV.IsPaneOpen;
        }

        /// <summary>
        /// Changes view according to the pressed button 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (Home.IsSelected) {
                MainFrame.Navigate(typeof(HomeView));
                Title.Text = "Startseite";
            } else if (AllAlbums.IsSelected) {
                MainFrame.Navigate(typeof(AllAlbumsView));
                Title.Text = "Alle Alben";
            } else if (Favs.IsSelected) {
                MainFrame.Navigate(typeof(FavsView));
                Title.Text = "Meine Favoriten";
            } else if (Help.IsSelected){
                MainFrame.Navigate(typeof(HelpView));
                Title.Text = "Hilfe und Kurzanleitung";
            } else if (About.IsSelected) {
                MainFrame.Navigate(typeof(AboutView));
                Title.Text = "Über diese App";
            }
        }

        /// <summary>
        /// Function for handling the GoBack Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="backRequestedEventArgs"></param>
        private void SystemNavigationManagerOnBackRequested(object sender, BackRequestedEventArgs backRequestedEventArgs) {
            if (MainFrame.CanGoBack) {
                try {
                    var lastPageName = MainFrame.BackStack.Last().SourcePageType.Name;
                    if (lastPageName == "HomeView") {
                        MainFrame.GoBack();
                        Title.Text = "Startseite";
                    } else if (lastPageName == "AllAlbumsView") {
                        MainFrame.GoBack();
                        Title.Text = "Alle Alben";
                    } else if (lastPageName == "FavsView") {
                        MainFrame.GoBack();
                        Title.Text = "Meine Favoriten";
                    } else if (lastPageName == "HelpView") {
                        MainFrame.GoBack();
                        Title.Text = "Hilfe und Kurzanleitung";
                    } else if (lastPageName == "AboutView") {
                        MainFrame.GoBack();
                        Title.Text = "Über diese App";
                    } else if (lastPageName == "AlbumView") {
                        MainFrame.GoBack();
                        Title.Text = "Album";
                    } else if (lastPageName == "EntryView") {
                        MainFrame.GoBack();
                        Title.Text = "Eintrag";
                    } else if (lastPageName == "PhotoView") {
                        MainFrame.BackStack.RemoveAt(MainFrame.BackStackDepth - 1);
                        MainFrame.GoBack();
                    }
                    backRequestedEventArgs.Handled = true;
                } catch {
                    System.Diagnostics.Debug.WriteLine("MainPage: SysteNavigationManagerOnBackRequest: Failed to go one Page back!");
                    try {
                        MainFrame.BackStack.RemoveAt(MainFrame.BackStackDepth - 1);
                        MainFrame.GoBack();
                    } catch {
                        System.Diagnostics.Debug.WriteLine("MainPage: SysteNavigationManagerOnBackRequest: Failed to go two Pages back!");
                    }
                }
                               
            }
        }
    }
}
