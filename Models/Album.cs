using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace S18782_Daniel_Janus_Kolos2.Models
{
    public class Album
    {
        [Key]
        public int IdAlbum { get; set; }

        [Required]
        [MaxLength(30)]
        public string AlbumName { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        [Required]
        [ForeignKey("MusicLabel")]
        public int IdMusicLabel { get; set; }
        public MusicLabel MusicLabel { get; set; }

        public IList<Track> Track { get; set; }
    }
}
