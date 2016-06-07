using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imento.Models
{
    class Location
    {
        public int LocationId { get; set; }

        // Foreign Key for Album
        public string AlbumId { get; set; }
        [ForeignKey("AlbumId")]
        public Album Album { get; set; }

        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Description { get; set; }
    }
}
