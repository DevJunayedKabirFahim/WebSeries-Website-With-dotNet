using AutoMapper;
using BusinessEntityLayer;
using DataAccessLayer.EntityFramework;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class UserRequestService
    {
        public static List<UserRequestModel> Get()
        {
            var data = DataAccessFactory.UserRequestDataAccess().Get();
            var requests = new List<UserRequestModel>();
            foreach (var item in data)
            {
                var rq = new UserRequestModel()
                {
                    //Id = item.Id,
                    //VideoId = item.VideoId,
                    //VideoTitle = item.Video.VideoTitle,
                    //Comment = item.Comment,
                    //Rating = item.Rating,
                    //UserId = item.UserId,
                    //Name = item.User.Login.Name,

                    Id = item.Id,
                    UserId = item.UserId,
                    RequestTitle = item.RequestTitle,
                    RequestCategorie = item.RequestCategorie,
                    ImdbLink = item.ImdbLink,

                };
                requests.Add(rq);
            }
            return requests;
        }
        public static UserRequestModel Get(int id)
        {
            var item = DataAccessFactory.UserRequestDataAccess().Get(id);
            var request = new UserRequestModel()
            {
                Id = item.Id,
                UserId = item.UserId,
                RequestTitle = item.RequestTitle,
                RequestCategorie = item.RequestCategorie,
                ImdbLink = item.ImdbLink,
            };
            return request;
        }
        public static void Create(UserRequestModel ur)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<UserRequestModel, UserRequest>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<UserRequest>(ur);
            var isCreated = DataAccessFactory.UserRequestDataAccess().Create(data);
            if (!isCreated) throw new Exception("User Request not created");
        }

        public static void Update(UserRequestModel ureq)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<UserRequestModel, UserRequest>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<UserRequestModel, UserRequest>(ureq);
            var isUpdated = DataAccessFactory.UserRequestDataAccess().Update(data);
            if (!isUpdated) throw new Exception("Request not updated");
        }

        public static void Delete(int id)
        {
            var isDeleted = DataAccessFactory.UserRequestDataAccess().Delete(id);
            if (!isDeleted) throw new Exception("Request not deleted");
        }
    }
}
