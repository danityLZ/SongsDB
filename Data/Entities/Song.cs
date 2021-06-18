using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities 
{
    public class Song : BaseEntity
    {
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

        public virtual ICollection<Rating> Rating { get; set; }
    }
}
