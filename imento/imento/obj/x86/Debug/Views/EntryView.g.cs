﻿#pragma checksum "C:\Users\CB\Documents\GitHub\iMento\imento\imento\Views\EntryView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "952438A39FCDC7A1CC868A093E923EC6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace imento.Views
{
    partial class EntryView : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        internal class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Windows.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_Image_Source(global::Windows.UI.Xaml.Controls.Image obj, global::Windows.UI.Xaml.Media.ImageSource value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::Windows.UI.Xaml.Media.ImageSource) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.Media.ImageSource), targetNullValue);
                }
                obj.Source = value;
            }
        };

        private class EntryView_obj9_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IEntryView_Bindings
        {
            private global::imento.Models.PhotoViewModel dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.Image obj10;

            public EntryView_obj9_Bindings()
            {
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 10:
                        this.obj10 = (global::Windows.UI.Xaml.Controls.Image)target;
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 global::imento.Models.PhotoViewModel data = args.NewValue as global::imento.Models.PhotoViewModel;
                 if (args.NewValue != null && data == null)
                 {
                    throw new global::System.ArgumentException("Incorrect type passed into template. Based on the x:DataType global::imento.Models.PhotoViewModel was expected.");
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
                        this.SetDataRoot(args.Item as global::imento.Models.PhotoViewModel);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            ((global::Windows.UI.Xaml.Controls.StackPanel)args.ItemContainer.ContentTemplateRoot).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_((global::imento.Models.PhotoViewModel) args.Item, 1 << (int)args.Phase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
            }

            // IEntryView_Bindings

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

            // EntryView_obj9_Bindings

            public void SetDataRoot(global::imento.Models.PhotoViewModel newDataRoot)
            {
                this.dataRoot = newDataRoot;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::imento.Models.PhotoViewModel obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_Photo(obj.Photo, phase);
                    }
                }
            }
            private void Update_Photo(global::Windows.UI.Xaml.Media.Imaging.BitmapImage obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Image_Source(this.obj10, obj, null);
                }
            }
        }

        private class EntryView_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IEntryView_Bindings
        {
            private global::imento.Views.EntryView dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.GridView obj8;

            private EntryView_obj1_BindingsTracking bindingsTracking;

            public EntryView_obj1_Bindings()
            {
                this.bindingsTracking = new EntryView_obj1_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 8:
                        this.obj8 = (global::Windows.UI.Xaml.Controls.GridView)target;
                        break;
                    default:
                        break;
                }
            }

            // IEntryView_Bindings

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
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            // EntryView_obj1_Bindings

            public void SetDataRoot(global::imento.Views.EntryView newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.dataRoot = newDataRoot;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::imento.Views.EntryView obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_Photos(obj.Photos, phase);
                    }
                }
            }
            private void Update_Photos(global::System.Collections.ObjectModel.ObservableCollection<global::imento.Models.PhotoViewModel> obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj8, obj, null);
                }
            }

            private class EntryView_obj1_BindingsTracking
            {
                global::System.WeakReference<EntryView_obj1_Bindings> WeakRefToBindingObj; 

                public EntryView_obj1_BindingsTracking(EntryView_obj1_Bindings obj)
                {
                    WeakRefToBindingObj = new global::System.WeakReference<EntryView_obj1_Bindings>(obj);
                }

                public void ReleaseAllListeners()
                {
                }

                public void PropertyChanged_Photos(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    EntryView_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        string propName = e.PropertyName;
                        global::System.Collections.ObjectModel.ObservableCollection<global::imento.Models.PhotoViewModel> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::imento.Models.PhotoViewModel>;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                        }
                        else
                        {
                            switch (propName)
                            {
                                default:
                                    break;
                            }
                        }
                    }
                }
                public void CollectionChanged_Photos(object sender, global::System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
                {
                    EntryView_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        global::System.Collections.ObjectModel.ObservableCollection<global::imento.Models.PhotoViewModel> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::imento.Models.PhotoViewModel>;
                    }
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
            case 2:
                {
                    this.x = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 3:
                {
                    this.MyGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 4:
                {
                    this.editEntry = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 38 "..\..\..\Views\EntryView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.editEntry).Click += this.editEntry_Click;
                    #line default
                }
                break;
            case 5:
                {
                    this.EntryTitleHeadline = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6:
                {
                    global::Windows.UI.Xaml.Controls.Button element6 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 42 "..\..\..\Views\EntryView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element6).Click += this.NewPhoto_Click;
                    #line default
                }
                break;
            case 7:
                {
                    this.deleteEntry = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 43 "..\..\..\Views\EntryView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.deleteEntry).Click += this.deleteEntry_Click;
                    #line default
                }
                break;
            case 8:
                {
                    global::Windows.UI.Xaml.Controls.GridView element8 = (global::Windows.UI.Xaml.Controls.GridView)(target);
                    #line 45 "..\..\..\Views\EntryView.xaml"
                    ((global::Windows.UI.Xaml.Controls.GridView)element8).ItemClick += this.GridView_ItemClick;
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
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    EntryView_obj1_Bindings bindings = new EntryView_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            case 9:
                {
                    global::Windows.UI.Xaml.Controls.StackPanel element9 = (global::Windows.UI.Xaml.Controls.StackPanel)target;
                    EntryView_obj9_Bindings bindings = new EntryView_obj9_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot((global::imento.Models.PhotoViewModel) element9.DataContext);
                    element9.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element9, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

