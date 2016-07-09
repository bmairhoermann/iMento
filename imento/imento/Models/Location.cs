using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imento.Models
{
    /// <summary>
    /// Class that sets the Modelstructure of a Location
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Database identifier
        /// </summary>
        public int LocationId { get; set; }

        /// <summary>
        /// Foreign Key for Album
        /// </summary>
        public string AlbumId { get; set; }
        [ForeignKey("AlbumId")]
        public Album Album { get; set; }

        /// <summary>
        /// Location attributes
        /// </summary>
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Description { get; set; }
    }
}
