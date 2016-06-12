﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imento.Models
{
    class Photo
    {
        public int PhotoId { get; set; }

        // ForeignKey for Entrys
        public int EntryId { get; set; }
        [ForeignKey("EntryId")]
        public Entry Entry { get; set; }

        public byte[] ImageByteArray { get; set; }
    }
}