using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class SongVM
    {
        public int Id { get; set; }

        [Required]        
        [StringLength(50)]
        public string Title { get; set; }

        [Required]        
        [StringLength(50)]
        public string Author { get; set; }

        [Required]
        [DisplayName("Year of release")]
        [Range(0, 2021)]
        public short YearReleased { get; set; }

        public float Lenght { get; set; }

        public SongVM() { }

        public SongVM(SongDTO songDTO)
        {
            Id = songDTO.Id;
            Title = songDTO.Title;
            Author = songDTO.Author;
            YearReleased = songDTO.YearReleased;
            Lenght = songDTO.Lenght;
        }        
    }
}