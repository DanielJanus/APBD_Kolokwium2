using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace S18782_Daniel_Janus_Kolos2.Models
{
    public class Track
    {
        [Key]
        public int IdTrack { get; set; }

        [Required]
        [MaxLength(20)]
        public string TrackName { get; set; }

        [Required]
        public float Duration { get; set; }

        [ForeignKey("Album")]
        public int? IdMusicAlbum { get; set; }
        public Album Album { get; set; }

        public IList<Musican_Track> Musican_Track { get; set; }
    }
}
