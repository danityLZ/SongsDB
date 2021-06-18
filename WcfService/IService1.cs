﻿using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here

        //SongManagementService
        [OperationContract]
        List<SongDTO> GetSongs(string filter);

        [OperationContract]
        SongDTO GetSongById(int id);

        [OperationContract]
        string PostSong(SongDTO songDto);

        [OperationContract]
        string PutSong(SongDTO songDto);

        [OperationContract]
        string DeleteSong(int id);

        //UserManagementService
        [OperationContract]
        List<UserDTO> GetUsers(string filter);

        [OperationContract]
        UserDTO GetUsersById(int id);

        [OperationContract]
        string PostUser(UserDTO userDto);

        [OperationContract]
        string PutUser(UserDTO userDto);

        [OperationContract]
        string DeleteUser(int id);

        //RatingManagementService
        [OperationContract]
        List<RatingDTO> GetRatings(string filter);

        [OperationContract]
        RatingDTO GetRatingsById(int id);

        [OperationContract]
        string PostRating(RatingDTO ratingDto);

        [OperationContract]
        string PutRating(RatingDTO ratingDto);

        [OperationContract]
        string DeleteRating(int id);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WcfService.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}