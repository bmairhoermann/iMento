﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace imento.Models {
    /// <summary>
    /// Class that defines the model structure for an Entry shown in the View
    /// </summary>
    class EntryViewModel {

        public int EntryId;
        public string Title;
        public string Description;
        public BitmapImage Photo;


    }
}
