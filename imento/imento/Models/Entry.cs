using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imento.Models
{
    class Entry
    {
        public int EntryId { get; set; }

        // Foreign Key for Album
        public string AlbumId { get; set; }
        [ForeignKey("AlbumId")]
        public Album Album { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public List<Photo> Photos { get; set; }
    }
}
