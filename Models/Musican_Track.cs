using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace S18782_Daniel_Janus_Kolos2.Models
{
    public class Musican_Track
    {
        [Key]
        public int IdMusicianTrack { get; set; }

        [Required]
        [ForeignKey("Track")]
        public int IdTrack { get; set; }
        public Track Track { get; set; }

        [Required]
        [ForeignKey("Musician")]
        public int IdMusician { get; set; }
        public Musican Musican { get; set; }
    }
}
