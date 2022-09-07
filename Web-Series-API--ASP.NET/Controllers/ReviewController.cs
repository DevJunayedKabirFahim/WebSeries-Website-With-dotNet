using BusinessEntityLayer;
using BusinessLogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web_Series_API__ASP.NET.Controllers
{
    public class ReviewController : ApiController
    {
        [Route("api/reviews")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, ReviewService.Get());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error no review found.", e);
            }
        }
        [Route("api/review/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, ReviewService.Get(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error review not found.", e);
            }
        }
        [Route("api/review/create")]
        [HttpPost]
        public HttpResponseMessage Post(ReviewModel r)
        {
            try
            {
                ReviewService.Create(r);
                return Request.CreateResponse(HttpStatusCode.Created, "User review added successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error adding user-review.", e);
            }
        }
        [Route("api/review/edit")]
        [HttpPut]
        public HttpResponseMessage Put(ReviewModel review)
        {
            try
            {
                ReviewService.Update(review);
                return Request.CreateResponse(HttpStatusCode.OK, "User review updated successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating review.", e);
            }
        }
        [Route("api/review/remove/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                ReviewService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.Created, "User review removed successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error action while removing review.", e);
            }
        }
    }
}
