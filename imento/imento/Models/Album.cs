using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imento.Models {
    /// <summary>
    /// Class that sets the Modelstructure of an Album
    /// </summary>
    public class Album {

        /// <summary>
        /// Database identifier
        /// </summary>
        public string AlbumId { get; set; }

        /// <summary>
        /// Album attributes
        /// </summary>
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime Date_Start { get; set; }
        public DateTime Date_Ende { get; set; }

        public Location Location { get; set; }

        public List<Entry> Entries { get; set; }
    }
}

