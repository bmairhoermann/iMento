﻿#pragma checksum "C:\Users\CB\Documents\GitHub\iMento\imento\imento\Views\HomeView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "93D588D85C17F944F261A97BB2D22C74"
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
    partial class HomeView : 
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
                    this.Map = (global::Windows.UI.Xaml.Controls.Maps.MapControl)(target);
                    #line 18 "..\..\..\Views\HomeView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Maps.MapControl)this.Map).MapElementClick += this.Map_MapElementClick;
                    #line 22 "..\..\..\Views\HomeView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Maps.MapControl)this.Map).MapHolding += this.Map_MapHolding;
                    #line default
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

