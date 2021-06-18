using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class RatingDTO
    {
        public int Id { get; set; }

        [Required]
        [Range(0, 5)]
        public byte Rate { get; set; }

        [Required]
        [StringLength(100)]
        public string Review { get; set; }

        public int SongID { get; set; }
        public virtual Song Song { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
