using ApplicationService.DTOs;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class RatingVM
    {
        public int Id { get; set; }        

        [Required]
        [Range(0, 5)]
        public byte Rate { get; set; }

        [Required]
        [StringLength(100)]
        public string Review { get; set; }

        [Display(Name = "Song")]
        public int SongID { get; set; }
        public SongVM SongVM { get; set; }

        [Display(Name = "User")]
        public int UserID { get; set; }
        public UserVM UserVM { get; set; }

        public RatingVM() { }

        public RatingVM(RatingDTO ratingDTO)
        {
            Id = ratingDTO.Id;
            Rate = ratingDTO.Rate;
            Review = ratingDTO.Review;
            SongID = ratingDTO.Song.Id;
            UserID = ratingDTO.User.Id;

            SongVM = new SongVM
            {
                Id = ratingDTO.Song.Id
            };

            UserVM = new UserVM
            {
                Id = ratingDTO.User.Id
            };
        }
    }
}