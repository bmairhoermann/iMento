﻿#pragma checksum "C:\Users\Philipp\Desktop\iMento\imento\imento\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2398B156974F1F48E0FFFACB0415791C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace imento
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.desx = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 2:
                {
                    this.MainSV = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 3:
                {
                    global::Windows.UI.Xaml.Controls.ListBox element3 = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                    #line 40 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListBox)element3).SelectionChanged += this.ListBox_SelectionChanged;
                    #line default
                }
                break;
            case 4:
                {
                    this.Home = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 5:
                {
                    this.AllAlbums = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 6:
                {
                    this.Favs = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 7:
                {
                    this.Settings = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 8:
                {
                    this.Help = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 9:
                {
                    this.About = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 10:
                {
                    this.AboutButton = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11:
                {
                    this.HelpButton = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12:
                {
                    this.SettingsButton = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13:
                {
                    this.FavsButton = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 14:
                {
                    this.AllAlbumsButton = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 15:
                {
                    this.HomeButton = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 16:
                {
                    this.MainFrame = (global::Windows.UI.Xaml.Controls.Frame)(target);
                }
                break;
            case 17:
                {
                    this.OpenMenu = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 29 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.OpenMenu).Click += this.OpenMainMenu;
                    #line default
                }
                break;
            case 18:
                {
                    this.GoBack = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 30 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.GoBack).Click += this.GoBack_Click;
                    #line default
                }
                break;
            case 19:
                {
                    this.Title = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

