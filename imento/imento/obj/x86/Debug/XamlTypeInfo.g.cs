﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



namespace imento
{
    public partial class App : global::Windows.UI.Xaml.Markup.IXamlMetadataProvider
    {
    private global::imento.imento_XamlTypeInfo.XamlTypeInfoProvider _provider;

        /// <summary>
        /// GetXamlType(Type)
        /// </summary>
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(global::System.Type type)
        {
            if(_provider == null)
            {
                _provider = new global::imento.imento_XamlTypeInfo.XamlTypeInfoProvider();
            }
            return _provider.GetXamlTypeByType(type);
        }

        /// <summary>
        /// GetXamlType(String)
        /// </summary>
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(string fullName)
        {
            if(_provider == null)
            {
                _provider = new global::imento.imento_XamlTypeInfo.XamlTypeInfoProvider();
            }
            return _provider.GetXamlTypeByName(fullName);
        }

        /// <summary>
        /// GetXmlnsDefinitions()
        /// </summary>
        public global::Windows.UI.Xaml.Markup.XmlnsDefinition[] GetXmlnsDefinitions()
        {
            return new global::Windows.UI.Xaml.Markup.XmlnsDefinition[0];
        }
    }
}

namespace imento.imento_XamlTypeInfo
{
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal partial class XamlTypeInfoProvider
    {
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByType(global::System.Type type)
        {
            global::Windows.UI.Xaml.Markup.IXamlType xamlType;
            if (_xamlTypeCacheByType.TryGetValue(type, out xamlType))
            {
                return xamlType;
            }
            int typeIndex = LookupTypeIndexByType(type);
            if(typeIndex != -1)
            {
                xamlType = CreateXamlType(typeIndex);
            }
            if (xamlType != null)
            {
                _xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
                _xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByName(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlType xamlType;
            if (_xamlTypeCacheByName.TryGetValue(typeName, out xamlType))
            {
                return xamlType;
            }
            int typeIndex = LookupTypeIndexByName(typeName);
            if(typeIndex != -1)
            {
                xamlType = CreateXamlType(typeIndex);
            }
            if (xamlType != null)
            {
                _xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
                _xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlMember GetMemberByLongName(string longMemberName)
        {
            if (string.IsNullOrEmpty(longMemberName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlMember xamlMember;
            if (_xamlMembers.TryGetValue(longMemberName, out xamlMember))
            {
                return xamlMember;
            }
            xamlMember = CreateXamlMember(longMemberName);
            if (xamlMember != null)
            {
                _xamlMembers.Add(longMemberName, xamlMember);
            }
            return xamlMember;
        }

        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType>
                _xamlTypeCacheByName = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType>();

        global::System.Collections.Generic.Dictionary<global::System.Type, global::Windows.UI.Xaml.Markup.IXamlType>
                _xamlTypeCacheByType = new global::System.Collections.Generic.Dictionary<global::System.Type, global::Windows.UI.Xaml.Markup.IXamlType>();

        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember>
                _xamlMembers = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember>();

        string[] _typeNameTable = null;
        global::System.Type[] _typeTable = null;

        private void InitTypeTables()
        {
            _typeNameTable = new string[21];
            _typeNameTable[0] = "imento.AboutView";
            _typeNameTable[1] = "Windows.UI.Xaml.Controls.Page";
            _typeNameTable[2] = "Windows.UI.Xaml.Controls.UserControl";
            _typeNameTable[3] = "imento.Views.AddPhoto";
            _typeNameTable[4] = "Windows.UI.Xaml.Controls.ContentDialog";
            _typeNameTable[5] = "Windows.UI.Xaml.Controls.ContentControl";
            _typeNameTable[6] = "Boolean";
            _typeNameTable[7] = "imento.Views.AddEntry";
            _typeNameTable[8] = "String";
            _typeNameTable[9] = "Int32";
            _typeNameTable[10] = "imento.Views.AlbumView";
            _typeNameTable[11] = "imento.AllAlbumsView";
            _typeNameTable[12] = "imento.Views.ContentDialogMap";
            _typeNameTable[13] = "imento.Views.EntryView";
            _typeNameTable[14] = "imento.FavsView";
            _typeNameTable[15] = "imento.HelpView";
            _typeNameTable[16] = "imento.HomeView";
            _typeNameTable[17] = "imento.MainPage";
            _typeNameTable[18] = "imento.NewAlbumView";
            _typeNameTable[19] = "imento.Views.PhotoView";
            _typeNameTable[20] = "imento.SettingsView";

            _typeTable = new global::System.Type[21];
            _typeTable[0] = typeof(global::imento.AboutView);
            _typeTable[1] = typeof(global::Windows.UI.Xaml.Controls.Page);
            _typeTable[2] = typeof(global::Windows.UI.Xaml.Controls.UserControl);
            _typeTable[3] = typeof(global::imento.Views.AddPhoto);
            _typeTable[4] = typeof(global::Windows.UI.Xaml.Controls.ContentDialog);
            _typeTable[5] = typeof(global::Windows.UI.Xaml.Controls.ContentControl);
            _typeTable[6] = typeof(global::System.Boolean);
            _typeTable[7] = typeof(global::imento.Views.AddEntry);
            _typeTable[8] = typeof(global::System.String);
            _typeTable[9] = typeof(global::System.Int32);
            _typeTable[10] = typeof(global::imento.Views.AlbumView);
            _typeTable[11] = typeof(global::imento.AllAlbumsView);
            _typeTable[12] = typeof(global::imento.Views.ContentDialogMap);
            _typeTable[13] = typeof(global::imento.Views.EntryView);
            _typeTable[14] = typeof(global::imento.FavsView);
            _typeTable[15] = typeof(global::imento.HelpView);
            _typeTable[16] = typeof(global::imento.HomeView);
            _typeTable[17] = typeof(global::imento.MainPage);
            _typeTable[18] = typeof(global::imento.NewAlbumView);
            _typeTable[19] = typeof(global::imento.Views.PhotoView);
            _typeTable[20] = typeof(global::imento.SettingsView);
        }

        private int LookupTypeIndexByName(string typeName)
        {
            if (_typeNameTable == null)
            {
                InitTypeTables();
            }
            for (int i=0; i<_typeNameTable.Length; i++)
            {
                if(0 == string.CompareOrdinal(_typeNameTable[i], typeName))
                {
                    return i;
                }
            }
            return -1;
        }

        private int LookupTypeIndexByType(global::System.Type type)
        {
            if (_typeTable == null)
            {
                InitTypeTables();
            }
            for(int i=0; i<_typeTable.Length; i++)
            {
                if(type == _typeTable[i])
                {
                    return i;
                }
            }
            return -1;
        }

        private object Activate_0_AboutView() { return new global::imento.AboutView(); }
        private object Activate_7_AddEntry() { return new global::imento.Views.AddEntry(); }
        private object Activate_10_AlbumView() { return new global::imento.Views.AlbumView(); }
        private object Activate_11_AllAlbumsView() { return new global::imento.AllAlbumsView(); }
        private object Activate_13_EntryView() { return new global::imento.Views.EntryView(); }
        private object Activate_14_FavsView() { return new global::imento.FavsView(); }
        private object Activate_15_HelpView() { return new global::imento.HelpView(); }
        private object Activate_16_HomeView() { return new global::imento.HomeView(); }
        private object Activate_17_MainPage() { return new global::imento.MainPage(); }
        private object Activate_18_NewAlbumView() { return new global::imento.NewAlbumView(); }
        private object Activate_19_PhotoView() { return new global::imento.Views.PhotoView(); }
        private object Activate_20_SettingsView() { return new global::imento.SettingsView(); }

        private global::Windows.UI.Xaml.Markup.IXamlType CreateXamlType(int typeIndex)
        {
            global::imento.imento_XamlTypeInfo.XamlSystemBaseType xamlType = null;
            global::imento.imento_XamlTypeInfo.XamlUserType userType;
            string typeName = _typeNameTable[typeIndex];
            global::System.Type type = _typeTable[typeIndex];

            switch (typeIndex)
            {

            case 0:   //  imento.AboutView
                userType = new global::imento.imento_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_0_AboutView;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 1:   //  Windows.UI.Xaml.Controls.Page
                xamlType = new global::imento.imento_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 2:   //  Windows.UI.Xaml.Controls.UserControl
                xamlType = new global::imento.imento_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 3:   //  imento.Views.AddPhoto
                userType = new global::imento.imento_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.ContentDialog"));
                userType.AddMemberName("photoWasAdded");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 4:   //  Windows.UI.Xaml.Controls.ContentDialog
                xamlType = new global::imento.imento_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 5:   //  Windows.UI.Xaml.Controls.ContentControl
                xamlType = new global::imento.imento_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 6:   //  Boolean
                xamlType = new global::imento.imento_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 7:   //  imento.Views.AddEntry
                userType = new global::imento.imento_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.ContentDialog"));
                userType.Activator = Activate_7_AddEntry;
                userType.AddMemberName("Title");
                userType.AddMemberName("Desc");
                userType.AddMemberName("Id");
                userType.AddMemberName("hasChanged");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 8:   //  String
                xamlType = new global::imento.imento_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 9:   //  Int32
                xamlType = new global::imento.imento_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 10:   //  imento.Views.AlbumView
                userType = new global::imento.imento_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_10_AlbumView;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 11:   //  imento.AllAlbumsView
                userType = new global::imento.imento_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_11_AllAlbumsView;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 12:   //  imento.Views.ContentDialogMap
                userType = new global::imento.imento_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.ContentDialog"));
                userType.AddMemberName("AlbumId");
                userType.AddMemberName("AlbumTitle");
                userType.AddMemberName("AlbumDescription");
                userType.AddMemberName("AlbumType");
                userType.AddMemberName("hasChanged");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 13:   //  imento.Views.EntryView
                userType = new global::imento.imento_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_13_EntryView;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 14:   //  imento.FavsView
                userType = new global::imento.imento_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_14_FavsView;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 15:   //  imento.HelpView
                userType = new global::imento.imento_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_15_HelpView;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 16:   //  imento.HomeView
                userType = new global::imento.imento_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_16_HomeView;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 17:   //  imento.MainPage
                userType = new global::imento.imento_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_17_MainPage;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 18:   //  imento.NewAlbumView
                userType = new global::imento.imento_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_18_NewAlbumView;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 19:   //  imento.Views.PhotoView
                userType = new global::imento.imento_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_19_PhotoView;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 20:   //  imento.SettingsView
                userType = new global::imento.imento_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_20_SettingsView;
                userType.SetIsLocalType();
                xamlType = userType;
                break;
            }
            return xamlType;
        }


        private object get_0_AddPhoto_photoWasAdded(object instance)
        {
            var that = (global::imento.Views.AddPhoto)instance;
            return that.photoWasAdded;
        }
        private void set_0_AddPhoto_photoWasAdded(object instance, object Value)
        {
            var that = (global::imento.Views.AddPhoto)instance;
            that.photoWasAdded = (global::System.Boolean)Value;
        }
        private object get_1_AddEntry_Title(object instance)
        {
            var that = (global::imento.Views.AddEntry)instance;
            return that.Title;
        }
        private void set_1_AddEntry_Title(object instance, object Value)
        {
            var that = (global::imento.Views.AddEntry)instance;
            that.Title = (global::System.String)Value;
        }
        private object get_2_AddEntry_Desc(object instance)
        {
            var that = (global::imento.Views.AddEntry)instance;
            return that.Desc;
        }
        private void set_2_AddEntry_Desc(object instance, object Value)
        {
            var that = (global::imento.Views.AddEntry)instance;
            that.Desc = (global::System.String)Value;
        }
        private object get_3_AddEntry_Id(object instance)
        {
            var that = (global::imento.Views.AddEntry)instance;
            return that.Id;
        }
        private void set_3_AddEntry_Id(object instance, object Value)
        {
            var that = (global::imento.Views.AddEntry)instance;
            that.Id = (global::System.Int32)Value;
        }
        private object get_4_AddEntry_hasChanged(object instance)
        {
            var that = (global::imento.Views.AddEntry)instance;
            return that.hasChanged;
        }
        private void set_4_AddEntry_hasChanged(object instance, object Value)
        {
            var that = (global::imento.Views.AddEntry)instance;
            that.hasChanged = (global::System.Boolean)Value;
        }
        private object get_5_ContentDialogMap_AlbumId(object instance)
        {
            var that = (global::imento.Views.ContentDialogMap)instance;
            return that.AlbumId;
        }
        private void set_5_ContentDialogMap_AlbumId(object instance, object Value)
        {
            var that = (global::imento.Views.ContentDialogMap)instance;
            that.AlbumId = (global::System.String)Value;
        }
        private object get_6_ContentDialogMap_AlbumTitle(object instance)
        {
            var that = (global::imento.Views.ContentDialogMap)instance;
            return that.AlbumTitle;
        }
        private void set_6_ContentDialogMap_AlbumTitle(object instance, object Value)
        {
            var that = (global::imento.Views.ContentDialogMap)instance;
            that.AlbumTitle = (global::System.String)Value;
        }
        private object get_7_ContentDialogMap_AlbumDescription(object instance)
        {
            var that = (global::imento.Views.ContentDialogMap)instance;
            return that.AlbumDescription;
        }
        private void set_7_ContentDialogMap_AlbumDescription(object instance, object Value)
        {
            var that = (global::imento.Views.ContentDialogMap)instance;
            that.AlbumDescription = (global::System.String)Value;
        }
        private object get_8_ContentDialogMap_AlbumType(object instance)
        {
            var that = (global::imento.Views.ContentDialogMap)instance;
            return that.AlbumType;
        }
        private void set_8_ContentDialogMap_AlbumType(object instance, object Value)
        {
            var that = (global::imento.Views.ContentDialogMap)instance;
            that.AlbumType = (global::System.String)Value;
        }
        private object get_9_ContentDialogMap_hasChanged(object instance)
        {
            var that = (global::imento.Views.ContentDialogMap)instance;
            return that.hasChanged;
        }
        private void set_9_ContentDialogMap_hasChanged(object instance, object Value)
        {
            var that = (global::imento.Views.ContentDialogMap)instance;
            that.hasChanged = (global::System.Boolean)Value;
        }

        private global::Windows.UI.Xaml.Markup.IXamlMember CreateXamlMember(string longMemberName)
        {
            global::imento.imento_XamlTypeInfo.XamlMember xamlMember = null;
            global::imento.imento_XamlTypeInfo.XamlUserType userType;

            switch (longMemberName)
            {
            case "imento.Views.AddPhoto.photoWasAdded":
                userType = (global::imento.imento_XamlTypeInfo.XamlUserType)GetXamlTypeByName("imento.Views.AddPhoto");
                xamlMember = new global::imento.imento_XamlTypeInfo.XamlMember(this, "photoWasAdded", "Boolean");
                xamlMember.Getter = get_0_AddPhoto_photoWasAdded;
                xamlMember.Setter = set_0_AddPhoto_photoWasAdded;
                break;
            case "imento.Views.AddEntry.Title":
                userType = (global::imento.imento_XamlTypeInfo.XamlUserType)GetXamlTypeByName("imento.Views.AddEntry");
                xamlMember = new global::imento.imento_XamlTypeInfo.XamlMember(this, "Title", "String");
                xamlMember.SetIsDependencyProperty();
                xamlMember.Getter = get_1_AddEntry_Title;
                xamlMember.Setter = set_1_AddEntry_Title;
                break;
            case "imento.Views.AddEntry.Desc":
                userType = (global::imento.imento_XamlTypeInfo.XamlUserType)GetXamlTypeByName("imento.Views.AddEntry");
                xamlMember = new global::imento.imento_XamlTypeInfo.XamlMember(this, "Desc", "String");
                xamlMember.Getter = get_2_AddEntry_Desc;
                xamlMember.Setter = set_2_AddEntry_Desc;
                break;
            case "imento.Views.AddEntry.Id":
                userType = (global::imento.imento_XamlTypeInfo.XamlUserType)GetXamlTypeByName("imento.Views.AddEntry");
                xamlMember = new global::imento.imento_XamlTypeInfo.XamlMember(this, "Id", "Int32");
                xamlMember.Getter = get_3_AddEntry_Id;
                xamlMember.Setter = set_3_AddEntry_Id;
                break;
            case "imento.Views.AddEntry.hasChanged":
                userType = (global::imento.imento_XamlTypeInfo.XamlUserType)GetXamlTypeByName("imento.Views.AddEntry");
                xamlMember = new global::imento.imento_XamlTypeInfo.XamlMember(this, "hasChanged", "Boolean");
                xamlMember.Getter = get_4_AddEntry_hasChanged;
                xamlMember.Setter = set_4_AddEntry_hasChanged;
                break;
            case "imento.Views.ContentDialogMap.AlbumId":
                userType = (global::imento.imento_XamlTypeInfo.XamlUserType)GetXamlTypeByName("imento.Views.ContentDialogMap");
                xamlMember = new global::imento.imento_XamlTypeInfo.XamlMember(this, "AlbumId", "String");
                xamlMember.Getter = get_5_ContentDialogMap_AlbumId;
                xamlMember.Setter = set_5_ContentDialogMap_AlbumId;
                break;
            case "imento.Views.ContentDialogMap.AlbumTitle":
                userType = (global::imento.imento_XamlTypeInfo.XamlUserType)GetXamlTypeByName("imento.Views.ContentDialogMap");
                xamlMember = new global::imento.imento_XamlTypeInfo.XamlMember(this, "AlbumTitle", "String");
                xamlMember.Getter = get_6_ContentDialogMap_AlbumTitle;
                xamlMember.Setter = set_6_ContentDialogMap_AlbumTitle;
                break;
            case "imento.Views.ContentDialogMap.AlbumDescription":
                userType = (global::imento.imento_XamlTypeInfo.XamlUserType)GetXamlTypeByName("imento.Views.ContentDialogMap");
                xamlMember = new global::imento.imento_XamlTypeInfo.XamlMember(this, "AlbumDescription", "String");
                xamlMember.Getter = get_7_ContentDialogMap_AlbumDescription;
                xamlMember.Setter = set_7_ContentDialogMap_AlbumDescription;
                break;
            case "imento.Views.ContentDialogMap.AlbumType":
                userType = (global::imento.imento_XamlTypeInfo.XamlUserType)GetXamlTypeByName("imento.Views.ContentDialogMap");
                xamlMember = new global::imento.imento_XamlTypeInfo.XamlMember(this, "AlbumType", "String");
                xamlMember.Getter = get_8_ContentDialogMap_AlbumType;
                xamlMember.Setter = set_8_ContentDialogMap_AlbumType;
                break;
            case "imento.Views.ContentDialogMap.hasChanged":
                userType = (global::imento.imento_XamlTypeInfo.XamlUserType)GetXamlTypeByName("imento.Views.ContentDialogMap");
                xamlMember = new global::imento.imento_XamlTypeInfo.XamlMember(this, "hasChanged", "Boolean");
                xamlMember.Getter = get_9_ContentDialogMap_hasChanged;
                xamlMember.Setter = set_9_ContentDialogMap_hasChanged;
                break;
            }
            return xamlMember;
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlSystemBaseType : global::Windows.UI.Xaml.Markup.IXamlType
    {
        string _fullName;
        global::System.Type _underlyingType;

        public XamlSystemBaseType(string fullName, global::System.Type underlyingType)
        {
            _fullName = fullName;
            _underlyingType = underlyingType;
        }

        public string FullName { get { return _fullName; } }

        public global::System.Type UnderlyingType
        {
            get
            {
                return _underlyingType;
            }
        }

        virtual public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name) { throw new global::System.NotImplementedException(); }
        virtual public bool IsArray { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsCollection { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsConstructible { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsDictionary { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsMarkupExtension { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsBindable { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsReturnTypeStub { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsLocalType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType ItemType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType KeyType { get { throw new global::System.NotImplementedException(); } }
        virtual public object ActivateInstance() { throw new global::System.NotImplementedException(); }
        virtual public void AddToMap(object instance, object key, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void AddToVector(object instance, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void RunInitializer()   { throw new global::System.NotImplementedException(); }
        virtual public object CreateFromString(string input)   { throw new global::System.NotImplementedException(); }
    }
    
    internal delegate object Activator();
    internal delegate void AddToCollection(object instance, object item);
    internal delegate void AddToDictionary(object instance, object key, object item);

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlUserType : global::imento.imento_XamlTypeInfo.XamlSystemBaseType
    {
        global::imento.imento_XamlTypeInfo.XamlTypeInfoProvider _provider;
        global::Windows.UI.Xaml.Markup.IXamlType _baseType;
        bool _isArray;
        bool _isMarkupExtension;
        bool _isBindable;
        bool _isReturnTypeStub;
        bool _isLocalType;

        string _contentPropertyName;
        string _itemTypeName;
        string _keyTypeName;
        global::System.Collections.Generic.Dictionary<string, string> _memberNames;
        global::System.Collections.Generic.Dictionary<string, object> _enumValues;

        public XamlUserType(global::imento.imento_XamlTypeInfo.XamlTypeInfoProvider provider, string fullName, global::System.Type fullType, global::Windows.UI.Xaml.Markup.IXamlType baseType)
            :base(fullName, fullType)
        {
            _provider = provider;
            _baseType = baseType;
        }

        // --- Interface methods ----

        override public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { return _baseType; } }
        override public bool IsArray { get { return _isArray; } }
        override public bool IsCollection { get { return (CollectionAdd != null); } }
        override public bool IsConstructible { get { return (Activator != null); } }
        override public bool IsDictionary { get { return (DictionaryAdd != null); } }
        override public bool IsMarkupExtension { get { return _isMarkupExtension; } }
        override public bool IsBindable { get { return _isBindable; } }
        override public bool IsReturnTypeStub { get { return _isReturnTypeStub; } }
        override public bool IsLocalType { get { return _isLocalType; } }

        override public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty
        {
            get { return _provider.GetMemberByLongName(_contentPropertyName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType ItemType
        {
            get { return _provider.GetXamlTypeByName(_itemTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType KeyType
        {
            get { return _provider.GetXamlTypeByName(_keyTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name)
        {
            if (_memberNames == null)
            {
                return null;
            }
            string longName;
            if (_memberNames.TryGetValue(name, out longName))
            {
                return _provider.GetMemberByLongName(longName);
            }
            return null;
        }

        override public object ActivateInstance()
        {
            return Activator(); 
        }

        override public void AddToMap(object instance, object key, object item) 
        {
            DictionaryAdd(instance, key, item);
        }

        override public void AddToVector(object instance, object item)
        {
            CollectionAdd(instance, item);
        }

        override public void RunInitializer() 
        {
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(UnderlyingType.TypeHandle);
        }

        override public object CreateFromString(string input)
        {
            if (_enumValues != null)
            {
                int value = 0;

                string[] valueParts = input.Split(',');

                foreach (string valuePart in valueParts) 
                {
                    object partValue;
                    int enumFieldValue = 0;
                    try
                    {
                        if (_enumValues.TryGetValue(valuePart.Trim(), out partValue))
                        {
                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                        }
                        else
                        {
                            try
                            {
                                enumFieldValue = global::System.Convert.ToInt32(valuePart.Trim());
                            }
                            catch( global::System.FormatException )
                            {
                                foreach( string key in _enumValues.Keys )
                                {
                                    if( string.Compare(valuePart.Trim(), key, global::System.StringComparison.OrdinalIgnoreCase) == 0 )
                                    {
                                        if( _enumValues.TryGetValue(key.Trim(), out partValue) )
                                        {
                                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        value |= enumFieldValue; 
                    }
                    catch( global::System.FormatException )
                    {
                        throw new global::System.ArgumentException(input, FullName);
                    }
                }

                return value; 
            }
            throw new global::System.ArgumentException(input, FullName);
        }

        // --- End of Interface methods

        public Activator Activator { get; set; }
        public AddToCollection CollectionAdd { get; set; }
        public AddToDictionary DictionaryAdd { get; set; }

        public void SetContentPropertyName(string contentPropertyName)
        {
            _contentPropertyName = contentPropertyName;
        }

        public void SetIsArray()
        {
            _isArray = true; 
        }

        public void SetIsMarkupExtension()
        {
            _isMarkupExtension = true;
        }

        public void SetIsBindable()
        {
            _isBindable = true;
        }

        public void SetIsReturnTypeStub()
        {
            _isReturnTypeStub = true;
        }

        public void SetIsLocalType()
        {
            _isLocalType = true;
        }

        public void SetItemTypeName(string itemTypeName)
        {
            _itemTypeName = itemTypeName;
        }

        public void SetKeyTypeName(string keyTypeName)
        {
            _keyTypeName = keyTypeName;
        }

        public void AddMemberName(string shortName)
        {
            if(_memberNames == null)
            {
                _memberNames =  new global::System.Collections.Generic.Dictionary<string,string>();
            }
            _memberNames.Add(shortName, FullName + "." + shortName);
        }

        public void AddEnumValue(string name, object value)
        {
            if (_enumValues == null)
            {
                _enumValues = new global::System.Collections.Generic.Dictionary<string, object>();
            }
            _enumValues.Add(name, value);
        }
    }

    internal delegate object Getter(object instance);
    internal delegate void Setter(object instance, object value);

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlMember : global::Windows.UI.Xaml.Markup.IXamlMember
    {
        global::imento.imento_XamlTypeInfo.XamlTypeInfoProvider _provider;
        string _name;
        bool _isAttachable;
        bool _isDependencyProperty;
        bool _isReadOnly;

        string _typeName;
        string _targetTypeName;

        public XamlMember(global::imento.imento_XamlTypeInfo.XamlTypeInfoProvider provider, string name, string typeName)
        {
            _name = name;
            _typeName = typeName;
            _provider = provider;
        }

        public string Name { get { return _name; } }

        public global::Windows.UI.Xaml.Markup.IXamlType Type
        {
            get { return _provider.GetXamlTypeByName(_typeName); }
        }

        public void SetTargetTypeName(string targetTypeName)
        {
            _targetTypeName = targetTypeName;
        }
        public global::Windows.UI.Xaml.Markup.IXamlType TargetType
        {
            get { return _provider.GetXamlTypeByName(_targetTypeName); }
        }

        public void SetIsAttachable() { _isAttachable = true; }
        public bool IsAttachable { get { return _isAttachable; } }

        public void SetIsDependencyProperty() { _isDependencyProperty = true; }
        public bool IsDependencyProperty { get { return _isDependencyProperty; } }

        public void SetIsReadOnly() { _isReadOnly = true; }
        public bool IsReadOnly { get { return _isReadOnly; } }

        public Getter Getter { get; set; }
        public object GetValue(object instance)
        {
            if (Getter != null)
                return Getter(instance);
            else
                throw new global::System.InvalidOperationException("GetValue");
        }

        public Setter Setter { get; set; }
        public void SetValue(object instance, object value)
        {
            if (Setter != null)
                Setter(instance, value);
            else
                throw new global::System.InvalidOperationException("SetValue");
        }
    }
}

