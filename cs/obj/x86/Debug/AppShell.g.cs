﻿#pragma checksum "C:\Users\Philipp\Desktop\Windows-universal-samples-master\Windows-universal-samples-master\Samples\XamlNavigation\shared\AppShell.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F6899FF958C71E90ED03E408134F7B41"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NavigationMenuSample
{
    partial class AppShell : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        internal class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_FontIcon_Glyph(global::Windows.UI.Xaml.Controls.FontIcon obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Glyph = value ?? global::System.String.Empty;
            }
            public static void Set_Windows_UI_Xaml_Controls_ToolTipService_ToolTip(global::Windows.UI.Xaml.FrameworkElement obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                global::Windows.UI.Xaml.Controls.ToolTipService.SetToolTip(obj, value);
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        private class AppShell_obj2_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IAppShell_Bindings
        {
            private global::NavigationMenuSample.NavMenuItem dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.FontIcon obj3;
            private global::Windows.UI.Xaml.Controls.TextBlock obj4;

            public AppShell_obj2_Bindings()
            {
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 3:
                        this.obj3 = (global::Windows.UI.Xaml.Controls.FontIcon)target;
                        break;
                    case 4:
                        this.obj4 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 global::NavigationMenuSample.NavMenuItem data = args.NewValue as global::NavigationMenuSample.NavMenuItem;
                 if (args.NewValue != null && data == null)
                 {
                    throw new global::System.ArgumentException("Incorrect type passed into template. Based on the x:DataType global::NavigationMenuSample.NavMenuItem was expected.");
                 }
                 this.SetDataRoot(data);
                 this.Update();
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                switch(args.Phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(args.Item as global::NavigationMenuSample.NavMenuItem);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            ((global::Windows.UI.Xaml.Controls.Grid)args.ItemContainer.ContentTemplateRoot).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_((global::NavigationMenuSample.NavMenuItem) args.Item, 1 << (int)args.Phase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
            }

            // IAppShell_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            // AppShell_obj2_Bindings

            public void SetDataRoot(global::NavigationMenuSample.NavMenuItem newDataRoot)
            {
                this.dataRoot = newDataRoot;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::NavigationMenuSample.NavMenuItem obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_SymbolAsChar(obj.SymbolAsChar, phase);
                        this.Update_Label(obj.Label, phase);
                    }
                }
            }
            private void Update_SymbolAsChar(global::System.Char obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_FontIcon_Glyph(this.obj3, obj.ToString(), null);
                }
            }
            private void Update_Label(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ToolTipService_ToolTip(this.obj3, obj, null);
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj4, obj, null);
                }
            }
        }
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
                    this.Root = (global::Windows.UI.Xaml.Controls.Page)(target);
                    #line 10 "..\..\..\AppShell.xaml"
                    ((global::Windows.UI.Xaml.Controls.Page)this.Root).KeyDown += this.AppShell_KeyDown;
                    #line default
                }
                break;
            case 5:
                {
                    this.LayoutRoot = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 6:
                {
                    this.RootSplitView = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                    #line 77 "..\..\..\AppShell.xaml"
                    ((global::Windows.UI.Xaml.Controls.SplitView)this.RootSplitView).PaneClosed += this.RootSplitView_PaneClosed;
                    #line default
                }
                break;
            case 7:
                {
                    this.TogglePaneButton = (global::Windows.UI.Xaml.Controls.Primitives.ToggleButton)(target);
                    #line 142 "..\..\..\AppShell.xaml"
                    ((global::Windows.UI.Xaml.Controls.Primitives.ToggleButton)this.TogglePaneButton).Unchecked += this.TogglePaneButton_Unchecked;
                    #line 143 "..\..\..\AppShell.xaml"
                    ((global::Windows.UI.Xaml.Controls.Primitives.ToggleButton)this.TogglePaneButton).Checked += this.TogglePaneButton_Checked;
                    #line default
                }
                break;
            case 8:
                {
                    this.NavMenuList = (global::NavigationMenuSample.Controls.NavMenuListView)(target);
                    #line 99 "..\..\..\AppShell.xaml"
                    ((global::NavigationMenuSample.Controls.NavMenuListView)this.NavMenuList).ContainerContentChanging += this.NavMenuItemContainerContentChanging;
                    #line 102 "..\..\..\AppShell.xaml"
                    ((global::NavigationMenuSample.Controls.NavMenuListView)this.NavMenuList).ItemInvoked += this.NavMenuList_ItemInvoked;
                    #line default
                }
                break;
            case 9:
                {
                    this.NavPaneDivider = (global::Windows.UI.Xaml.Shapes.Rectangle)(target);
                }
                break;
            case 10:
                {
                    this.FeedbackNavPaneButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 11:
                {
                    this.frame = (global::Windows.UI.Xaml.Controls.Frame)(target);
                    #line 122 "..\..\..\AppShell.xaml"
                    ((global::Windows.UI.Xaml.Controls.Frame)this.frame).Navigating += this.OnNavigatingToPage;
                    #line 123 "..\..\..\AppShell.xaml"
                    ((global::Windows.UI.Xaml.Controls.Frame)this.frame).Navigated += this.OnNavigatedToPage;
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
            switch(connectionId)
            {
            case 2:
                {
                    global::Windows.UI.Xaml.Controls.Grid element2 = (global::Windows.UI.Xaml.Controls.Grid)target;
                    AppShell_obj2_Bindings bindings = new AppShell_obj2_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot((global::NavigationMenuSample.NavMenuItem) element2.DataContext);
                    element2.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element2, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

