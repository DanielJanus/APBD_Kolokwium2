using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace S18782_Daniel_Janus_Kolos2.Models
{
    public class GetMusicList
    {
        [Required]
        public int IdMusicLabel { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int IdAlbum { get; set; }

        [Required]
        [MaxLength(30)]
        public string AlbumName { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }
    }
}
