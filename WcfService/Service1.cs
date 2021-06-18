using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ApplicationService.Implementations;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        //Users
        private UserManagementService userService = new UserManagementService();

        List<UserDTO> IService1.GetUsers(string filter)
        {
            return userService.Get(filter);
        }

        UserDTO IService1.GetUsersById(int id)
        {
            return userService.GetById(id);
        }

        string IService1.PostUser(UserDTO userDto)
        {
            if (!userService.Save(userDto))
            {
                return "User is not saved!";
            }
            else
            {
                return "User is saved!";
            }
        }

        string IService1.PutUser(UserDTO userDto)
        {
            if (!userService.Save(userDto))
            {
                return "User is not updated";
            }
            else
            {
                return "User is updated";
            }
        }        
        
        string IService1.DeleteUser(int id)
        {
            if (!userService.Delete(id))
            {
                return "User is not deleted!";
            }
            else
            {
                return "User is deleted!";
            }
        }

        //Songs
        private SongManagementService songService = new SongManagementService();
        
        List<SongDTO> IService1.GetSongs(string filter)
        {
            return songService.Get(filter);
        }

        SongDTO IService1.GetSongById(int id)
        {
            return songService.GetById(id);
        }        

        string IService1.PostSong(SongDTO songDto)
        {
            if (!songService.Save(songDto))
            {
                return "Song is not saved!";
            }
            else
            {
                return "Song is saved!";
            }
        }

        string IService1.PutSong(SongDTO songDto)
        {
            if (!songService.Save(songDto))
            {
                return "Song is not updated";
            }
            else
            {
                return "Song is updated";
            }
        }

        string IService1.DeleteSong(int id)
        {
            if (!songService.Delete(id))
            {
                return "Song is not deleted!";
            }
            else
            {
                return "Song is deleted!";
            }
        }

        //Ratings
        private RatingManagementService ratingService = new RatingManagementService();     

        List<RatingDTO> IService1.GetRatings(string filter)
        {
            return ratingService.Get(filter);
        }

        RatingDTO IService1.GetRatingsById(int id)
        {
            return ratingService.GetById(id);
        }

        string IService1.PostRating(RatingDTO ratingDto)
        {
            if (!ratingService.Save(ratingDto))
            {
                return "Rating is not saved!";
            }
            else
            {
                return "Rating is saved!";
            }
        }

        string IService1.PutRating(RatingDTO ratingDto)
        {
            if (!ratingService.Save(ratingDto))
            {
                return "Rating is not updated";
            }
            else
            {
                return "Rating is updated";
            }
        }

        string IService1.DeleteRating(int id)
        {
            if (!ratingService.Delete(id))
            {
                return "Rating is not deleted!";
            }
            else
            {
                return "Rating is deleted!";
            }
        }
    }
}
