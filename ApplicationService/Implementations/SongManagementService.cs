using ApplicationService.DTOs;
using Data.Context;
using Data.Entities;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementations
{
    public class SongManagementService
    {
        public List<SongDTO> Get(string filter)
        {
            List<SongDTO> songsDto = new List<SongDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.SongRepository.Get(x => x.Author.Contains(filter)))
                {
                    songsDto.Add(new SongDTO
                    {
                        Id = item.Id,
                        Title = item.Title,
                        Author = item.Author,
                        YearReleased = item.YearReleased,
                        Lenght = item.Lenght
                    });
                }
            }

            return songsDto;
        }

        public SongDTO GetById(int id)
        {
            SongDTO songDTO = new SongDTO();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Song song = unitOfWork.SongRepository.GetByID(id);
                songDTO = new SongDTO
                {
                    Id = song.Id,
                    Title = song.Title,
                    Author = song.Author,
                    YearReleased = song.YearReleased,
                    Lenght = song.Lenght
                };
            }
            return songDTO;
        }

        public bool Save(SongDTO songDTO)
        {
            Song Song = new Song
            {
                Id = songDTO.Id,
                Title = songDTO.Title,
                Author = songDTO.Author,
                YearReleased = songDTO.YearReleased,
                Lenght = songDTO.Lenght
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (songDTO.Id == 0)
                    {
                        unitOfWork.SongRepository.Insert(Song);
                        unitOfWork.Save();
                    }
                    else
                    {
                        unitOfWork.SongRepository.Update(Song);
                        unitOfWork.Save();
                    }
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
                    Song song = unitOfWork.SongRepository.GetByID(id);
                    unitOfWork.SongRepository.Delete(song);
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

