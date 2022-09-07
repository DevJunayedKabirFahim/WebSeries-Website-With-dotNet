using AutoMapper;
using BusinessEntityLayer;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ReviewService
    {
        public static List<ReviewModel> Get()
        {
            var data = DataAccessFactory.ReviewDataAccess().Get();
            var reviews = new List<ReviewModel>();
            foreach (var item in data)
            {
                var rv = new ReviewModel()
                {
                    Id = item.Id,
                    VideoId = item.VideoId,
                    VideoTitle = item.Video.VideoTitle,
                    Comment = item.Comment,
                    Rating = item.Rating,
                    UserId = item.UserId,
                    //Name = item.User.Login.Name,

                };
                reviews.Add(rv);
            }
            return reviews;
        }
        public static ReviewModel Get(int id)
        {
            var item = DataAccessFactory.ReviewDataAccess().Get(id);
            var review = new ReviewModel()
            {
                Id = item.Id,
                VideoId = item.VideoId,
                VideoTitle = item.Video.VideoTitle,
                Comment = item.Comment,
                Rating = item.Rating,
                UserId = item.UserId,
                //Name = item.User.Login.Name
            };
            return review;
        }
        public static void Create(ReviewModel r)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ReviewModel, Review>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Review>(r);
            var isCreated = DataAccessFactory.ReviewDataAccess().Create(data);
            if (!isCreated) throw new Exception("Review not created");
        }

        public static void Update(ReviewModel review)
        {
            Review rv = new Review();
            User user = new User();
            Video video = new Video();

            int Id = Convert.ToInt32(review.Id);
            rv.Id = review.Id;
            rv.Rating = review.Rating;
            rv.Comment = review.Comment;




            var isUpdatedForReview = DataAccessFactory.ReviewDataAccess().Update(rv);
            if (!isUpdatedForReview) throw new Exception("Review not updated");


        }

        public static void Delete(int id)
        {
            var isDeleted = DataAccessFactory.ReviewDataAccess().Delete(id);
            if (!isDeleted) throw new Exception("Review not deleted");
        }
    }
}
