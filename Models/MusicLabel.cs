﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace S18782_Daniel_Janus_Kolos2.Models
{
    public class MusicLabel
    {
        [Key]
        public int IdMusicLabel { get; set; }
           
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public IList<Album> Album { get; set; }
    }
}
