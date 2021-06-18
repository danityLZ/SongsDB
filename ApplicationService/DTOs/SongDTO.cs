using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class SongDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Author { get; set; }

        [Required]
        [Range(0, 2021)]
        public short YearReleased { get; set; }

        public float Lenght { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
