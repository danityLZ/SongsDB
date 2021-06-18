using ApplicationService.DTOs;
using Data.Entities;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementations
{
    public class RatingManagementService 
    {
        public List<RatingDTO> Get(string filter)
        {
            List<RatingDTO> RatingDto = new List<RatingDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.RatingRepository.Get(x => x.Review.Contains(filter)))
                {
                    RatingDto.Add(new RatingDTO
                    {
                        Id = item.Id,
                        Rate = item.Rate,
                        Review = item.Review,

                        User = new User
                        {
                            Id = item.UserID
                        },

                        Song = new Song
                        {
                            Id = item.Song.Id
                        }
                    });
                }
            }
            return RatingDto;
        }

        public RatingDTO GetById(int id)
        {
            RatingDTO RatingDto = new RatingDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Rating rating = unitOfWork.RatingRepository.GetByID(id);
                RatingDto = new RatingDTO
                {
                    Id = rating.Id,
                    Rate = rating.Rate,
                    Review = rating.Review,

                    User = new User
                    {
                        Id = rating.UserID
                    },

                    Song = new Song
                    {
                        Id = rating.Song.Id
                    }
                };
            }
            return RatingDto;
        }

        public bool Save(RatingDTO ratingDto)
        {
            Rating rating = new Rating
            {
                Id = ratingDto.Id,
                Rate = ratingDto.Rate,
                Review=ratingDto.Review,
                SongID = ratingDto.Song.Id,
                UserID = ratingDto.User.Id
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (ratingDto.Id == 0)
                        unitOfWork.RatingRepository.Insert(rating);
                    else
                        unitOfWork.RatingRepository.Update(rating);

                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Rating rating = unitOfWork.RatingRepository.GetByID(id);
                    unitOfWork.RatingRepository.Delete(rating);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
