using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imento.Models
{
    /// <summary>
    /// Class that sets the Modelstructure of an Entry
    /// </summary>
    public class Entry
    {
        /// <summary>
        /// Database identifier
        /// </summary>
        public int EntryId { get; set; }

        /// <summary>
        /// Foreign Key for Album
        /// </summary>
        public string AlbumId { get; set; }
        [ForeignKey("AlbumId")]
        public Album Album { get; set; }

        /// <summary>
        /// Entry attributes
        /// </summary>
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public List<Photo> Photos { get; set; }
    }
}
