using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace S18782_Daniel_Janus_Kolos2.Models
{
    public class Musican
    {
        [Key]
        public int IdMusican { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(20)]
        public string? Nickname { get; set; }

        public IList<Musican_Track> Musican_Track { get; set; }
    }
}
