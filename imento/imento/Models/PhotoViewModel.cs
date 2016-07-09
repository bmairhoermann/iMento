using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Media.Imaging;

namespace imento.Models {

    /// <summary>
    /// Class that defines the model structure of a Photo shown in the View
    /// </summary>
    class PhotoViewModel : INotifyPropertyChanged {

        private BitmapImage photo;
        public int PhotoId;

        public BitmapImage Photo {
            get { return photo; }
            set { if (!Equals(photo, value)) { photo = value; OnPropertyChanged(); } }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
