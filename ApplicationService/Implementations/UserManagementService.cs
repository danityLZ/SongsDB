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
    public class UserManagementService
    {
        private Song1SystemDBContext ctx = new Song1SystemDBContext();

        public List<UserDTO> Get(string filter)
        {
            List<UserDTO> usersDto = new List<UserDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.UserRepository.Get(x => x.FirstName.Contains(filter)))
                {
                    usersDto.Add(new UserDTO
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Age = item.Age,
                        DateOfBirth = item.DateOfBirth
                    });
                }
            }
            return usersDto;
        }

        public UserDTO GetById(int id)
        {
            UserDTO userDTO = new UserDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                User user = unitOfWork.UserRepository.GetByID(id);
                if (user != null)
                {
                    userDTO.Id = user.Id;
                    userDTO.FirstName = user.FirstName;
                    userDTO.LastName = user.LastName;
                    userDTO.Age = user.Age;
                    userDTO.DateOfBirth = user.DateOfBirth;                   
                }
            }
            return userDTO;
        }

        public bool Save(UserDTO userDTO)
        {
            User user = new User
            {
                Id = userDTO.Id,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Age = userDTO.Age,
                DateOfBirth = userDTO.DateOfBirth
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (userDTO.Id == 0)
                    {
                        unitOfWork.UserRepository.Insert(user);
                        unitOfWork.Save();
                    }
                    else
                    {
                        unitOfWork.UserRepository.Update(user);
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
                    User user = unitOfWork.UserRepository.GetByID(id);
                    unitOfWork.UserRepository.Delete(user);
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
